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

        public void addUniqueVertex(Vertex v)
        {
            if(!Vertices.Contains(v))
            {
                Vertices.Add(v);
            }
        }
        
        public void addRoads(IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            foreach(Tuple<Vector2, Vector2> road in roads)
            {
                Vertex vertex1 = new Vertex(road.Item1);
                Vertex vertex2 = new Vertex(road.Item2);
                Edge edge = new Edge(vertex1, vertex2);

                addUniqueVertex(vertex1);
                addUniqueVertex(vertex2);
                Edges.Add(edge);
            }
        }

        //TODO find connected vertices
    }
}
