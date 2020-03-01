using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    struct connnectedElement
    {
        NetworkElement element;
        bool beginOfElement;
    }
    class NetworkNode : INetworkObject
    {
        //Schemas.NetRelation readRelation;
        protected List<NetworkRelation> ownedRelations;
        protected List<NetworkElement> connectedElements;
        protected Point logicalCenter = Point.Empty;

        public NetworkNode() 
        {
            ID = "NetworkNode?";

            ownedRelations = new List<NetworkRelation>();
            connectedElements = new List<NetworkElement>();
        }
        internal virtual bool CanHandleConnections(int count)
        {
            if(count>1 )
            {
                return false;
            }
            return true;
        }
        internal void CopyConnections(NetworkNode orginalNode)
        {
            ownedRelations.AddRange(orginalNode.ownedRelations);
            connectedElements.AddRange(orginalNode.connectedElements);
            ID = orginalNode.ID;
        }

        public Point LogicalCenter { get => logicalCenter; }
        public string ID { get; set; }

        public void AddRelations(List<NetworkRelation> relations)
        {
            foreach(var rel in relations)
            {
                AddRelation(rel);
            }
        }
        public void AddConnectedElement(NetworkElement element,bool begin)
        {
            connectedElements.Add(element);
        }
        public virtual void AllElementsConnected(InfraReader infra)
        {
          
        }
        public bool AddRelation(NetworkRelation relation)
        {
            bool added = false;

            if (ownedRelations.Find(x => x == relation) == null)
            {
                if(ownedRelations.Count==0)
                {
                    ID = "relation-" + relation.ID;
                }
                ownedRelations.Add(relation);
                relation.ParentNode = this;
                
              
                added = true;
            }
            return added;
        }
    }
}
