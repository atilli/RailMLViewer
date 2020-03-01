using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    interface INetworkObject
    {
        public string ID { get; set; }
        public Point LogicalCenter { get; }
    }
    
}
