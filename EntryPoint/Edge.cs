using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Edge
    {
        public Vertex Vertex1 { get; set; }
        public Vertex Vertex2 { get; set; }
        public double weight { get; set; }

        public Edge(Vertex v1, Vertex v2)
        {
            Vertex1 = v1;
            Vertex2 = v2;
            weight = Program.DistanceBetween(v1.Location, v2.Location);
        }

        public Tuple<Vector2, Vector2> ToRoad()
        {
            return new Tuple<Vector2, Vector2>(Vertex1.Location, Vertex2.Location);
        }

        public Vertex getOtherVertex(Vertex currentVertex)
        {
            Vertex nextVertex = null;
            if (Vertex1.Equals(currentVertex))
                nextVertex = Vertex2;
            else if (Vertex2.Equals(currentVertex))
                nextVertex = Vertex1;

            return nextVertex;
        }

        public Edge getInverse()
        {
            Edge e = new Edge(Vertex2, Vertex1);
            e.weight = weight;
            return e;
        }
    }
}
