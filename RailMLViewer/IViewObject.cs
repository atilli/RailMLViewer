using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    interface IViewObject
    {
        bool DrawTo(Graphics g, ScalableViewPort viewPort, Size size);

        public string ID { get; set; }
        public string NameInView { get; set; }
        public INetworkObject ConnectedNetworkObject { get; }
    }
}
