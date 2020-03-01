using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class NetworkRelation : INetworkObject
    {
        Schemas.NetRelation readRelation;
        public Point LogicalCenter { get => Point.Empty; }
        public string ID { get; set; }

        public NetworkRelation(Schemas.NetRelation railMLSource)
        {
            readRelation = railMLSource;
            ID = railMLSource.Id;
        }
        public NetworkNode ParentNode { get; set; }
        public NetworkElement ElementA { get; set; }
        public NetworkElement ElementB { get; set; }
    }
}
