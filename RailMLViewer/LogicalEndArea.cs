using System;
using System.Collections.Generic;
using System.Text;

namespace RailMLViewer
{ 
    class LogicalEndArea : NetworkNode
    {
        public LogicalEndArea()
        {            

        }
        internal override bool CanHandleConnections(int count)
        {
            if (count > 0)
            {
                return false;
            }
            return true;
        }
    }
    
}
