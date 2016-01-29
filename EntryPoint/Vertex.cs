using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Vertex
    {
        public Vector2 Location { get; set; }
        public bool Visited { get; set; }
        public List<Edge> ConnectedEdges { get; set; }
        public Route Route { get; set; }

        public Vertex(Vector2 v, Route route)
        {
            Location = v;
            Visited = false;
            ConnectedEdges = new List<Edge>();
            if (route != null)
                Route = route;
            else
                Route = new Route(Double.MaxValue, null);
        }

        public void AddUniqueConnectedEdge(Edge e)
        {
            if (!ConnectedEdges.Contains(e))
                ConnectedEdges.Add(e);
        }
    }
}
