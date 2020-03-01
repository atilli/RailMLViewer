using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class PlatformBase : IOperationalPoint, INetworkObject
    {
        Schemas.Platform readPlatofrm;

        protected PlatformBase(Schemas.Platform railMLSource)
        {
            readPlatofrm = railMLSource;
            ID = railMLSource.Id;
        }
        
        public string ID { get; set; }
        public Point LogicalCenter { get => Point.Empty; } //todo ??

        public string OperationalID { get; set; }

        public bool OCPConfigured { get; set; }
    }
}
