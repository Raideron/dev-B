using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Graph
    {
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public Vertex addUniqueVertex(Vertex v)
        {
            Vertex foundVertex = Vertices.Find(x => x.Location == v.Location);
            if (foundVertex == null)
            {
                Vertices.Add(v);
                return v;
            }
            else
            {
                return foundVertex;
            }

        }

        public void addRoads(IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            foreach (Tuple<Vector2, Vector2> road in roads)
            {
                Vertex vertex1 = new Vertex(road.Item1);
                Vertex vertex2 = new Vertex(road.Item2);
                Edge edge = new Edge(vertex1, vertex2);

                vertex1 = addUniqueVertex(vertex1);
                vertex2 = addUniqueVertex(vertex2);
                Edges.Add(edge);

                vertex1.ConnectedVertices.Add(vertex1);
                vertex2.ConnectedVertices.Add(vertex2);
            }
        }
    }
}
