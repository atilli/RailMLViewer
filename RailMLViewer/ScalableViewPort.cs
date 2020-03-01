using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class ScalableViewPort
    {
        public ScalableViewPort()
        {
            startingOrigo = new Point(0, 0);
            viewPortOrigo = new Point(0, 0);

            step = 10;
            minPercentage = 10;
            currentPercentage = 100;
            scale = currentPercentage / 100F;
            maxPercentage = 500;
        }
        internal Line2d LogicalLineToScreen(Line2d logicalLine)
        {
            return new Line2d(LogicalXToScreenX(logicalLine.BeginX), LogicalYToScreenY(logicalLine.BeginY),
                 LogicalXToScreenX(logicalLine.EndX), LogicalYToScreenY(logicalLine.EndY));


        }
        internal void ZoomIn(Point screenPoint)
        {
            int logicalZoomLocationX = (int)ScreenXToLogical(screenPoint.X);
            int logicalZoomLocationY = (int)ScreenYToLogical(screenPoint.Y);

            ZoomInOneStep();

            // We move origo to try to keep mouse over point to point to same logical coordinates...
            viewPortOrigo.X = logicalZoomLocationX - (int)ScreenXLengthToLogical(screenPoint.X);
            viewPortOrigo.Y = logicalZoomLocationY - (int)ScreenYLengthToLogical(screenPoint.Y);
        }
        internal bool MoveOrigoScreenToScreen(Point oldScreenLoc, Point newScreenLoc)
        {
            bool moved = false;

            int screenMoveX = oldScreenLoc.X - newScreenLoc.X;
            int screenMoveY = oldScreenLoc.Y - newScreenLoc.Y;
            if(screenMoveX!=0 || screenMoveY!=0)
            {
                viewPortOrigo.X = (int) ScreenXToLogical(screenMoveX);
                viewPortOrigo.Y = (int) ScreenYToLogical(screenMoveY);
                moved = true;
            }
            return moved;
        }
        void ResetViewPort()
        {
            currentPercentage = 100;
            scale = currentPercentage / 100F;
            viewPortOrigo = startingOrigo;
        }
        internal void ZoomOut(Point screenPoint)
        {
            
            int logicalZoomLocationX = (int)ScreenXToLogical(screenPoint.X);
            int logicalZoomLocationY = (int)ScreenYToLogical(screenPoint.Y);

            ZoomOutOneStep();

            // We move origo to try to keep mouse over point to point to same logical coordinates...
            viewPortOrigo.X = logicalZoomLocationX - (int) ScreenXLengthToLogical(screenPoint.X);
            viewPortOrigo.Y = logicalZoomLocationY - (int) ScreenYLengthToLogical(screenPoint.Y);
            
        }
        void ZoomInOneStep()
        {
            currentPercentage += step;
            if(currentPercentage>=maxPercentage)
            {
                currentPercentage = maxPercentage;
                
            }
            scale = currentPercentage / 100F;
        }
        void ZoomOutOneStep()
        {
            currentPercentage -= step;
            if (currentPercentage <= minPercentage)
            {
                currentPercentage = minPercentage;
                
            }
            scale = currentPercentage / 100F;
        }
        // not that we have only one scale so two below methods are currenly similar...
        float ScreenXLengthToLogical(int screenXLen)
        {
            return (screenXLen / scale);
        }
        float ScreenYLengthToLogical(int screenYLen)
        {
            return (screenYLen / scale);
        }
        float ScreenXToLogical(int screenX)
        {
            return (screenX / scale) + viewPortOrigo.X;
        }
        float ScreenYToLogical(int screenY)
        {
            return (screenY / scale) + viewPortOrigo.Y;
        }
        
        public Point PointToScreen(Point logicalPoint)
        {
            return new Point(LogicalXToScreenX(logicalPoint.X),LogicalYToScreenY(logicalPoint.Y));
        }

        public int LogicalXToScreenX(int logicalX)
        {
            return System.Convert.ToInt32((float)(logicalX - viewPortOrigo.X) * scale);

        }
        public int LogicalYToScreenY(int logicalY)
        {
            return System.Convert.ToInt32((float)(logicalY - viewPortOrigo.Y) * scale);
        }

        Point viewPortOrigo;
        Point startingOrigo;

        int step;
        int minPercentage;
        int currentPercentage;
        float scale;
        int maxPercentage;
    }

}
