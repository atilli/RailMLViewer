using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class ViewNetworkNode : IViewObject
    {
        NetworkNode sourceObject;
        public ViewNetworkNode(NetworkNode node)
        {
            sourceObject = node;
            ID = node.ID + "-ViewObject";
            NameInView = node.ID;
        }
        public string NameInView { get; set; }
        public string ID { get; set; }
        public INetworkObject ConnectedNetworkObject { get => sourceObject; }

        public bool DrawTo(Graphics g, ScalableViewPort viewPort, Size size)
        {
            return false;
        }
    }
}
