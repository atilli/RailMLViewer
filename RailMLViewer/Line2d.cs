using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class Line2d
    {
        bool zeroLength;
        public Line2d(Point begin,Point end) : this(begin.X,begin.Y,end.X,end.Y)
        {
        
        }
        public Line2d(int bX, int bY, int eX, int eY)
        {
            this.beginX = bX;
            this.beginY = bY;
            this.endX = eX;
            this.endY = eY;

            if(beginX==0 && beginY==0 && endX==0 && endY==0)
            {
                zeroLength = true; //todo really cal len
            }
            else
            {
                zeroLength = false;
            }
        }
        public double Length()
        {
            int dx = endX - beginX;
            int dy = endY - beginY;

            return Math.Sqrt((dx * dx) + (dy * dy));
        }
        public bool ZeroLength { get => zeroLength;  }
        public int BeginX { get => beginX; }
        public int BeginY { get => beginY; }
        public int EndX { get => endX; }
        public int EndY { get => endY; }
        public PointF Fraction(float frac)
        {
            return new PointF(beginX + frac * (endX - beginX), beginY + frac * (endY - beginY));
        }
        public Point CenterPoint()
        {
            return new Point(beginX + (int)(0.5f * (endX - beginX)), (beginY + (int)(0.5f * (endY - beginY))));
        }
        protected int beginX;
        protected int beginY;
        protected int endX;        
        protected int endY;
    }
   
}
