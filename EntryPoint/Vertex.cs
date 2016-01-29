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
            foreach (Edge edge in ConnectedEdges)
            {
                Edge inverseEdge = e.getInverse();
                if (edge.Vertex1.Location.Equals(e.Vertex1.Location) && edge.Vertex2.Location.Equals(e.Vertex2.Location))
                {
                    return;
                }
                else if (edge.Vertex1.Location.Equals(inverseEdge.Vertex1.Location) && edge.Vertex2.Location.Equals(inverseEdge.Vertex2.Location))
                {
                    return;
                }
            }
            ConnectedEdges.Add(e);
        }
    }
}
