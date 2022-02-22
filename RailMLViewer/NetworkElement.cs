using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    public class NetworkElement : INetworkObject
    {
        List<NetworkRelation> fromRelations;
        List<NetworkRelation> toRelations;
        protected Point logicalCenter = Point.Empty;
        

        public string ID { get; set; }
        public NetworkElement(Schemas.NetElement railMLSource)
        {
            readElement = railMLSource;
            ID = railMLSource.Id;
            fromRelations = new List<NetworkRelation>();
            toRelations = new List<NetworkRelation>();

            if(!InifFromGeometryCoordinates(railMLSource)) {
                
                LogicalStartPoint = new Point(readElement.StartX, readElement.StartY);
                LogicalEndPoint = new Point(readElement.EndX, readElement.EndY);
            }                       
            logicalCenter = new Point((LogicalStartPoint.X + LogicalEndPoint.X) / 2, (LogicalStartPoint.Y + LogicalEndPoint.Y) / 2);

            Length = System.Convert.ToDouble(readElement.Length);

        }
        bool InifFromGeometryCoordinates(Schemas.NetElement element) {

            bool readSome = false;

            foreach(Schemas.RTM_AssociatedPositioningSystem position in element.AssociatedPositioningSystem) {
                
                foreach(Schemas.RTM_IntrinsicCoordinate coord in position.IntrinsicCoordinate) {
                    if(coord.GeometricCoordinateSpecified) {
                        foreach(Schemas.RTM_GeometricCoordinate geo in coord.GeometricCoordinate) {

                            readSome = true;

                            if(LogicalStartPoint.IsEmpty) {   
                                LogicalStartPoint = new Point((int)geo.X,(int)geo.Y);
                            }
                            else
                            {
                                if(LogicalEndPoint.IsEmpty) {   
                                    LogicalEndPoint = new Point((int)geo.X,(int)geo.Y);
                                }
                            }
                        }
                    }
                }
            }
            return readSome;
        }
        public Point LogicalCenter { get => logicalCenter; }
        internal Point LogicalStartPoint { get; set; }
        internal Point LogicalEndPoint { get; set; }

        public double Length { get; set; }
        internal List<NetworkRelation> FromRelations { get => fromRelations; }
        internal List<NetworkRelation> ToRelations { get => toRelations;  }

        internal NetworkNode From { get; set; }
        internal NetworkNode To { get; set; }

        Schemas.NetElement readElement;
    }
}
