using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class ViewNetworkElement : IViewObject
    {
        NetworkElement sourceObject;
        Line2d logicalLine;
        Line2d fromConnector;
        Line2d toConnector;
        Line2d drawedLine;

        public ViewNetworkElement(NetworkElement element)
        {
            sourceObject = element;
            ID = element.ID + "-ViewObject";
            NameInView = element.ID;
            logicalLine = new Line2d(element.LogicalStartPoint,element.LogicalEndPoint);

            if(element.From!=null)
            {
                Point fromPoint = element.From.LogicalCenter;
                if(fromPoint!=Point.Empty && !fromPoint.Equals(element.LogicalStartPoint))
                {
                    fromConnector = new Line2d(element.LogicalStartPoint, fromPoint);
                }

            }
            if (element.To != null)
            {
                Point toPoint = element.To.LogicalCenter;
                if (toPoint != Point.Empty && !toPoint.Equals(element.LogicalStartPoint))
                {
                    toConnector = new Line2d(element.LogicalEndPoint, toPoint);
                }
            }
        }
        internal PointF FractionPoint(double fraction)
        {
            return logicalLine.Fraction((float)fraction);
        }
        internal bool FractionPointOnDrawedLine(double fraction, out PointF point)
        {
            bool pointValid = false;

            point = PointF.Empty;

            if (drawedLine!=null)
            {

                point = drawedLine.Fraction((float)fraction);
                pointValid = true;
            }
            return pointValid;
        }
        public string NameInView { get; set; }
        public string ID { get; set; }
        public INetworkObject ConnectedNetworkObject { get => sourceObject; }
        public NetworkElement SourceElement { get => sourceObject; }
        void DrawViewLine(Graphics g,Pen linePen,Line2d line)
        {
            g.DrawLine(linePen, line.BeginX, line.BeginY,
                                    line.EndX, line.EndY);

        }
        public bool DrawTo(Graphics g, ScalableViewPort viewPort, Size size)
        {
            if (!logicalLine.ZeroLength)
            {
                drawedLine = viewPort.LogicalLineToScreen(logicalLine);

                using (Pen linePen = new Pen(Color.AntiqueWhite, 2.0f))
                {
                    DrawViewLine(g, linePen, drawedLine);

                    if(fromConnector != null)
                    {
                        Line2d fromLine = viewPort.LogicalLineToScreen(fromConnector);
                        DrawViewLine(g, linePen, fromLine);

                    }
                    if (toConnector != null)
                    {
                        Line2d toLine = viewPort.LogicalLineToScreen(toConnector);
                        DrawViewLine(g, linePen, toLine);

                    }

                    using (SolidBrush tx = new SolidBrush(Color.Aqua))
                    {
                        g.DrawString(NameInView, SystemFonts.SmallCaptionFont, tx, drawedLine.CenterPoint());
                    }
                }
            }

            return true;
        }

    }
}
