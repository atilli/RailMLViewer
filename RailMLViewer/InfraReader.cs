using System;
using System.Collections.Generic;
using System.Text;

namespace RailMLViewer
{
    public class InfraReader
    {
        XSD.railML railMLDoc;
        Dictionary<string, NetworkElement> _networkElements;
        Dictionary<string, NetworkRelation> _networkRelations;
        Dictionary<string, NetworkNode> _networkNodes;
        Dictionary<string, PlatformEdge> _platformEdges;
        Dictionary<string, PlatformArea> _platformAreas;


        internal Dictionary<string, NetworkElement> NetworkElements { get => _networkElements;  }
        internal Dictionary<string, NetworkNode> NetworkNodes { get => _networkNodes;  }

        internal Dictionary<string, PlatformEdge> PlatformEdges { get => _platformEdges; }
        public bool InitFromFile(string file)
        {

            bool ok = false;

            railMLDoc = XMLReader.DeSerializeObject<XSD.railML>(file, out string error);

            if (String.IsNullOrEmpty(error))
            {
                BuildNetwork(railMLDoc.infra);
                ok = true;
            }
            return ok;
        }
        public NetworkElement FindNetworkElement(string id)
        {
            NetworkElement ret = null;
            _networkElements.TryGetValue(id, out ret);
            return ret;
        }
        internal PlatformEdge FindPlatformEdge(string id)
        {
            PlatformEdge ret = null;
            _platformEdges.TryGetValue(id, out ret);
            return ret;
        }
        public void BuildNetwork(Schemas.Infrastructure infraElement)
        {
            _networkElements = new Dictionary<string, NetworkElement>();
            _networkNodes = new Dictionary<string, NetworkNode>();
            _platformEdges = new Dictionary<string, PlatformEdge>();
            _platformAreas = new Dictionary<string, PlatformArea>();
            _networkRelations = new Dictionary<string, NetworkRelation>();


            CreateNetworkElements(infraElement.Topology.NetElements);
            CreateNetworkRelations(infraElement.Topology.NetRelations);
            CreateNetworkNodes();
            CreatePlatforms(infraElement.FunctionalInfrastructure.Platforms);

        }
        void CreatePlatforms(System.Collections.ObjectModel.Collection<Schemas.Platform> platforms)
        {
            foreach (Schemas.Platform railMLPlat in platforms)
            {
                var edgesIDCollection = railMLPlat.OwnsPlatformEdge;
                
                if(edgesIDCollection!=null && edgesIDCollection.Count>0)
                {

                }
                else
                {
                    PlatformEdge platEdge = new PlatformEdge(railMLPlat);
                    _platformEdges[platEdge.ID] = platEdge;

                    if(railMLPlat.LinearLocationSpecified)
                    {
                        foreach (Schemas.RTM_LinearLocation linearLocation in railMLPlat.LinearLocation)
                        {
                            foreach (var netElemnet in linearLocation.AssociatedNetElement)
                            {
                                NetworkElement found = this.FindNetworkElement(netElemnet.NetElementRef);
                                // for now just one location for edge...
                                if(found!=null && platEdge.Location==null)
                                {
                                    platEdge.Location = found;
                                    platEdge.FromPos = System.Convert.ToDouble(netElemnet.PosBegin);
                                    platEdge.ToPos = System.Convert.ToDouble(netElemnet.PosEnd);
                                }
                            }
                        }                        
                    }
                }

            }
            foreach (Schemas.Platform railMLPlat in platforms)
            {
                var edgesIDCollection = railMLPlat.OwnsPlatformEdge;

                if (edgesIDCollection != null && edgesIDCollection.Count > 0)
                {
                    PlatformArea platFrom = new PlatformArea(railMLPlat);

                    foreach(var child in edgesIDCollection)
                    {
                        PlatformEdge edge = FindPlatformEdge(child.Ref);
                        if(edge!=null)
                        {
                            platFrom.Add(edge);
                        }

                    }
                    _platformAreas[platFrom.ID] = platFrom;
                }
                else
                {
                    
                }

            }
        }
        public void CreateNetworkElements(System.Collections.ObjectModel.Collection<Schemas.NetElement> netElements)
        {
            foreach (var element in netElements)
            {
                NetworkElement createdElement = new NetworkElement(element);

                _networkElements[createdElement.ID] = createdElement;
            }
        }
        public void CreateNetworkRelations(System.Collections.ObjectModel.Collection<Schemas.NetRelation> netRelations)
        {

            foreach (var netRelation in netRelations)
            {
                var navigationSelector = netRelation.Navigability;
                var createdRelation = new NetworkRelation(netRelation);

                NetworkElement elementA = FindNetworkElement(netRelation.ElementA.Ref);
                NetworkElement elementB = FindNetworkElement(netRelation.ElementB.Ref);
                if(elementA!=null && elementB!=null)
                {
                    createdRelation.ElementA = elementA;
                    createdRelation.ElementB = elementB;

                    if (netRelation.PositionOnA==Schemas.TUsage.Item0)
                    {
                        elementA.FromRelations.Add(createdRelation);
                    }
                    else
                    {
                        elementA.ToRelations.Add(createdRelation);
                    }
                    if (netRelation.PositionOnB == Schemas.TUsage.Item0)
                    {
                        elementB.FromRelations.Add(createdRelation);
                    }
                    else
                    {
                        elementB.ToRelations.Add(createdRelation);
                    }
                    _networkRelations[createdRelation.ID] = createdRelation;
                }
                /*if (navigationSelector == Schemas.TNavigability.None)
                {
                    var createdEOL = new LogicalEndArea(netRelation);

                }*/

            }
        }
        NetworkNode FindAlreadyCreatedNode(List<NetworkRelation> list)
        {
            NetworkNode found = null;
            foreach(var relation in list)
            {
                if(relation.ParentNode!=null)
                {
                    found = relation.ParentNode;
                    break;
                }
            }
            return found;
        }
        internal NetworkNode CreateNode(int connectedElemensCount)
        {
            NetworkNode created = null;

            if (connectedElemensCount >= 2)
            {
                created = new LogicalJunction();
            }
            if (connectedElemensCount == 1)
            {
                created = new TrackMarker();
            }
            if (connectedElemensCount == 0)
            {
                created = new LogicalEndArea();
            }
            return created;
        }
        NetworkNode CheckOrCreateNodeFor(List<NetworkRelation> relations)
        {
            NetworkNode node = FindAlreadyCreatedNode(relations);
            bool oldNode = false;

            if (node == null)
            {
                node = CreateNode(relations.Count);                
            }
            else
            {
                oldNode = true;
                
                if(!node.CanHandleConnections(relations.Count))
                {
                    NetworkNode newNode = CreateNode(relations.Count);
                    newNode.CopyConnections(node);
                    node = newNode;
                    oldNode = false;
                }
            }
            if (node != null)
            {
                node.AddRelations(relations);
                if(!oldNode)
                {
                    _networkNodes[node.ID] = node;
                }
            }
            return node;
        }
        public void CreateNetworkNodes()
        {

            foreach(NetworkElement elmentToCheck in _networkElements.Values)
            {              

                NetworkNode fromNode = CheckOrCreateNodeFor(elmentToCheck.FromRelations);
                elmentToCheck.From = fromNode;
                fromNode.AddConnectedElement(elmentToCheck, true);

                NetworkNode toNode = CheckOrCreateNodeFor(elmentToCheck.ToRelations);
                elmentToCheck.To = toNode;
                toNode.AddConnectedElement(elmentToCheck, false);
            }
            foreach (NetworkNode node in _networkNodes.Values)
            {
                node.AllElementsConnected(this);
            }
            /*foreach (var netRelation in netRelations)
            {
                var navigationSelector = netRelation.Navigability;
                
                if(navigationSelector==Schemas.TNavigability.None)
                {
                    var createdEOL = new LogicalEndArea(netRelation);

                }
                
            }*/
        }
    }
  
}
