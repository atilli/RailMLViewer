using System;
using System.Collections.Generic;
using System.Text;

namespace RailMLViewer
{
    class PlatformEdge : PlatformBase
    {

        public PlatformEdge(Schemas.Platform railMLSource) : base(railMLSource)
        {

         

        }
        public double FromPos { get; set; }
        public double ToPos { get; set; }
        public NetworkElement Location { get; set; }
        public PlatformArea Parent { get; set;  }
    }
}
