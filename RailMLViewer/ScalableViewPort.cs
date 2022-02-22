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
            _startingOrigo = new Point(0, 0);
            _viewPortOrigo = new Point(0, 0);

            _step = 5;
            _minPercentage = 1;
            _currentPercentage = 100;
            _scale = _currentPercentage / 100F;
            _maxPercentage = 500;
        }
        internal Line2d LogicalLineToScreen(Line2d logicalLine)
        {
            return new Line2d(LogicalXToScreenX(logicalLine.BeginX), LogicalYToScreenY(logicalLine.BeginY),
                 LogicalXToScreenX(logicalLine.EndX), LogicalYToScreenY(logicalLine.EndY));


        }
        public string BuildDebugString() {
            return $"X = {_viewPortOrigo.X}, X = {_viewPortOrigo.Y}, {_currentPercentage}";
        }
        internal void ZoomIn(Point screenPoint)
        {
            int logicalZoomLocationX = (int)ScreenXToLogical(screenPoint.X);
            int logicalZoomLocationY = (int)ScreenYToLogical(screenPoint.Y);

            ZoomInOneStep();

            // We move origo to try to keep mouse over point to point to same logical coordinates...
            _viewPortOrigo.X = logicalZoomLocationX - (int)ScreenXLengthToLogical(screenPoint.X);
            _viewPortOrigo.Y = logicalZoomLocationY - (int)ScreenYLengthToLogical(screenPoint.Y);
        }
        internal bool MoveOrigoScreenToScreen(Point oldScreenLoc, Point newScreenLoc)
        {
            bool moved = false;

            int screenMoveX = oldScreenLoc.X - newScreenLoc.X;
            int screenMoveY = oldScreenLoc.Y - newScreenLoc.Y;
            if(screenMoveX!=0 || screenMoveY!=0)
            {
                _viewPortOrigo.X = (int) ScreenXToLogical(screenMoveX);
                _viewPortOrigo.Y = (int) ScreenYToLogical(screenMoveY);
                moved = true;
            }
            return moved;
        }
        void ResetViewPort()
        {
            _currentPercentage = 100;
            _scale = _currentPercentage / 100F;
            _viewPortOrigo = _startingOrigo;
        }
        internal void ZoomOut(Point screenPoint)
        {
            
            int logicalZoomLocationX = (int)ScreenXToLogical(screenPoint.X);
            int logicalZoomLocationY = (int)ScreenYToLogical(screenPoint.Y);

            ZoomOutOneStep();

            // We move origo to try to keep mouse over point to point to same logical coordinates...
            _viewPortOrigo.X = logicalZoomLocationX - (int) ScreenXLengthToLogical(screenPoint.X);
            _viewPortOrigo.Y = logicalZoomLocationY - (int) ScreenYLengthToLogical(screenPoint.Y);
            
        }
        void ZoomInOneStep()
        {
            _currentPercentage += _step;
            if(_currentPercentage>=_maxPercentage)
            {
                _currentPercentage = _maxPercentage;
                
            }
            _scale = _currentPercentage / 100F;
        }
        void ZoomOutOneStep()
        {
            _currentPercentage -= _step;
            if (_currentPercentage <= _minPercentage)
            {
                _currentPercentage = _minPercentage;
                
            }
            _scale = _currentPercentage / 100F;
        }
        // not that we have only one scale so two below methods are currenly similar...
        float ScreenXLengthToLogical(int screenXLen)
        {
            return (screenXLen / _scale);
        }
        float ScreenYLengthToLogical(int screenYLen)
        {
            return (screenYLen / _scale);
        }
        float ScreenXToLogical(int screenX)
        {
            return (screenX / _scale) + _viewPortOrigo.X;
        }
        float ScreenYToLogical(int screenY)
        {
            return (screenY / _scale) + _viewPortOrigo.Y;
        }
        
        public Point PointToScreen(Point logicalPoint)
        {
            return new Point(LogicalXToScreenX(logicalPoint.X),LogicalYToScreenY(logicalPoint.Y));
        }

        public int LogicalXToScreenX(int logicalX)
        {
            return System.Convert.ToInt32((float)(logicalX - _viewPortOrigo.X) * _scale);

        }
        public int LogicalYToScreenY(int logicalY)
        {
            return System.Convert.ToInt32((float)(logicalY - _viewPortOrigo.Y) * _scale);
        }
        public void SetIntialCenter(PointF center) {

            _startingOrigo = Point.Round(center);

            _viewPortOrigo = _startingOrigo;

        }

        Point _viewPortOrigo;
        Point _startingOrigo;

        int _step;
        int _minPercentage;
        int _currentPercentage;
        float _scale;
        int _maxPercentage;
    }

}
