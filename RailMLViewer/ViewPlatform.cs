using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class ViewPlatform : IViewObject
    {
      

        PlatformEdge sourceObject;
        internal ViewNetworkElement OnElement { get; set; }

        public ViewPlatform(PlatformEdge platformEdge)
        {
            sourceObject = platformEdge;
            ID = platformEdge.ID + "-ViewObject";
            NameInView = platformEdge.ID;
        }
        double fractionFrom;
        double fractionTo;
        bool fractionsValid = false;

        public void UpdateFractions()
        {
            NetworkElement networkElement = OnElement?.SourceElement;

            if (networkElement != null)
            {
                fractionFrom = sourceObject.FromPos / networkElement.Length;
                fractionTo  = sourceObject.ToPos / networkElement.Length;
                fractionsValid = true;
            }
        }
        public string NameInView { get; set; }
        public string ID { get; set; }

        public INetworkObject ConnectedNetworkObject { get => sourceObject; }
        public bool DrawTo(Graphics g, ScalableViewPort viewPort, Size size)
        {
            if (fractionsValid)
            {
                if (OnElement.FractionPointOnDrawedLine(fractionFrom, out PointF start) &&
                    OnElement.FractionPointOnDrawedLine(fractionTo, out PointF end))
                {

                    using (Pen linePen = new Pen(Color.Green, 4.0f))
                    {
                        g.DrawLine(linePen, start, end);
                        /*using (SolidBrush tx = new SolidBrush(Color.Aqua))
                        {
                            g.DrawString(NameInView, SystemFonts.SmallCaptionFont, tx, lineInView.CenterPoint());
                        }*/
                    }
                }
            }
            /*if (!lineInView.ZeroLength)
            {
                using (Pen linePen = new Pen(Color.AntiqueWhite, 2.0f))
                {
                    g.DrawLine(linePen, lineInView.StartX, lineInView.StartY,
                                     lineInView.EndX, lineInView.EndY);

                    using (SolidBrush tx = new SolidBrush(Color.Aqua))
                    {
                        g.DrawString(NameInView, SystemFonts.SmallCaptionFont, tx, lineInView.CenterPoint());
                    }
                }
            }*/

            return true;
        }
    }
}
