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
            
            LogicalStartPoint = new Point(readElement.StartX, readElement.StartY);
            LogicalEndPoint = new Point(readElement.EndX, readElement.EndY);

            logicalCenter = new Point(readElement.StartX + readElement.EndX / 2, readElement.StartY + readElement.StartY / 2);

            Length = System.Convert.ToDouble(readElement.Length);

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
