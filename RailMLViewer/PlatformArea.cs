using System;
using System.Collections.Generic;
using System.Text;

namespace RailMLViewer
{
    // In Rail ML this is not network object, but functional infra..
    class PlatformArea : PlatformBase
    {
        public PlatformArea(Schemas.Platform railMLSource) : base(railMLSource)
        {
            platformEdges = new Dictionary<string, PlatformEdge>();
        }
        public void Add(PlatformEdge edge)
        {
            edge.Parent = this;
            platformEdges[edge.ID] = edge;
        }
        Dictionary<string, PlatformEdge> platformEdges;

        public Dictionary<string, PlatformEdge> PlatformEdges { get => platformEdges; }
    }
}

