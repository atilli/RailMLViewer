using System;
using System.Collections.Generic;
using System.Text;

namespace RailMLViewer
{
    interface IOperationalPoint
    {
        string OperationalID { get; set; }
        bool OCPConfigured { get; set; }
    }
}
