using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RailMLViewer
{
    class LogicalJunction : NetworkNode
    {
        class PointCount
        {
            internal PointCount(Point point)
            {
                pointData = point;
                count = 1;
            }
            public Point pointData;
            public int count;
        }
        internal override bool CanHandleConnections(int count)
        {
            return true;
        }
        public LogicalJunction() 
        {
            counts = new List<PointCount>(); 
        }
        List<PointCount> counts;
        Point GetLogicalCenter(List<PointCount> list)
        {
            Point retPoint = Point.Empty;

            int bestCount = 0;

            foreach (PointCount count in list)
            {
                if(count.count>bestCount)
                {
                    retPoint = count.pointData;
                    bestCount = count.count;
                }
            }
            return retPoint;
        }
        void AddPoint(Point pointToAdd,List<PointCount> list)
        {
            bool newLocation = true;

            foreach(PointCount count in list)
            {
                if(count.pointData.Equals(pointToAdd))
                {
                    newLocation = false;
                    count.count++;
                    break;
                }
            }
            if(newLocation)
            {
                PointCount oneCount = new PointCount(pointToAdd);
                list.Add(oneCount);
            }
        }
        public override void AllElementsConnected(InfraReader infra)
        {
          

            foreach (NetworkElement element in connectedElements)
            {
                //Point NetworkElement
                if(element.From==this)
                {
                    Point point = element.LogicalStartPoint;
                    if(!point.IsEmpty)
                    {
                        AddPoint(point, counts);
                    }
                }
                if(element.To==this)
                {
                    Point point = element.LogicalEndPoint;
                    if (!point.IsEmpty)
                    {
                        AddPoint(point, counts);
                    }
                }                
            }
            Point newLogicalCenter = GetLogicalCenter(counts); 
            if(newLogicalCenter!=Point.Empty)
            {
                this.logicalCenter = newLogicalCenter;
            }

        }
    }
}
