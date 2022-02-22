using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class NetworkViewData
    {
        Dictionary<string, ViewNetworkElement> trackElements;
        Dictionary<string, ViewNetworkNode> trackNodes;
        Dictionary<string, ViewPlatform> platForms;

        public NetworkViewData()
        {
            trackElements = new Dictionary<string, ViewNetworkElement>();
            trackNodes = new Dictionary<string, ViewNetworkNode>();
            platForms = new Dictionary<string, ViewPlatform>();
        }
        ViewNetworkElement FindMatchingViewElement(NetworkElement element)
        {
            ViewNetworkElement found = null;

            foreach (ViewNetworkElement viewElement in trackElements.Values)
            {
                if (viewElement.ConnectedNetworkObject == element)
                {
                    found = viewElement;
                    break;
                }
            }
            return found;
        }
        public PointF CalcAverageCenter() {

            float x = 0F;
            float y = 0F;
            int count = 0;

               
            foreach(ViewNetworkElement element in trackElements.Values) {

                Point center = element.GetLogicalCenter();
                if(!center.IsEmpty) {
                    x += (float) center.X;
                    y += (float) center.Y;
                    count++;
                }
            }
            if(count>0) {
                return new PointF(x/(float)count,y/(float)count);
            }
            else {
                return new PointF();
            }

        }
        public void CreateViewObjectsFor(InfraReader netWork)
        {
            Dictionary<string, NetworkElement> sourceElements = netWork.NetworkElements;
            foreach (NetworkElement element in sourceElements.Values)
            {
                ViewNetworkElement elementInView = new ViewNetworkElement(element);
                trackElements[elementInView.ID] = elementInView;
            }

            Dictionary<string, PlatformEdge> sourcePlatforms = netWork.PlatformEdges;

            foreach (PlatformEdge platformEdge in sourcePlatforms.Values)
            {
                ViewPlatform platformInView = new ViewPlatform(platformEdge);

                ViewNetworkElement elementInView = FindMatchingViewElement(platformEdge.Location);

                if (elementInView != null)
                {
                    platformInView.OnElement = elementInView;
                    platformInView.UpdateFractions();
                }
                platForms[platformInView.ID] = platformInView;
            }
        }
        internal void DrawNetworkTo(Graphics g, ScalableViewPort viewPortToUse, Size size)
        {
            using (SolidBrush bgBrush = new SolidBrush(Color.DarkGray))
            {
                g.FillRectangle(bgBrush, 0, 0, size.Width, size.Height);
            }
            foreach (ViewNetworkElement element in trackElements.Values)
            {
                element.DrawTo(g, viewPortToUse, size);
            }
            foreach (ViewPlatform platform in platForms.Values)
            {
                platform.DrawTo(g, viewPortToUse, size);
            }
        }
    }
}
