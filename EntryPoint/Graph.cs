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
        //TODO remove these two below
        private int counter = 0;
        //List<Edge> possibleRoutes = new List<Edge>();

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public List<Tuple<Vector2, Vector2>> FindRoute(Vector2 startVector, Vector2 endVector)
        {
            List<Tuple<Vector2, Vector2>> returnValue = new List<Tuple<Vector2, Vector2>>();
            Vertex startVertex = Vertices.Find(x => x.Location == startVector);
            Vertex endVertex = Vertices.Find(x => x.Location == endVector);


            startVertex.Route.Distance = 0;
            visitNextVertex(startVertex);

            foreach (Edge edge in endVertex.Route.Edges)
            {
                returnValue.Add(edge.ToRoad());
            }

            return returnValue;
        }

        private void visitNextVertex(Vertex currentVertex)
        {
            int localCounter = 0;
            currentVertex.Visited = true;
            foreach (Edge edge in currentVertex.ConnectedEdges)
            {
                localCounter++;
                counter++;
                Vertex nextVertex = null;
                if (edge.Vertex1.Equals(currentVertex))
                    nextVertex = edge.Vertex2;
                else if (edge.Vertex2.Equals(currentVertex))
                    nextVertex = edge.Vertex1;

                double newDistance = currentVertex.Route.Distance + edge.weight;
                double oldDistance = nextVertex.Route.Distance;
                
                if (newDistance < oldDistance)
                {
                    Route newRoute = new Route(currentVertex.Route.Distance, currentVertex.Route.Edges);
                    newRoute.Edges.Add(edge);
                    newRoute.Distance = newDistance;
                    nextVertex.Route = newRoute;
                    nextVertex.Visited = false;
                }

                if (!nextVertex.Visited)
                {
                    visitNextVertex(nextVertex);
                }
            }
        }



        public void AddRoads(IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            foreach (Tuple<Vector2, Vector2> road in roads)
            {
                Vertex vertex1 = new Vertex(road.Item1, null);
                Vertex vertex2 = new Vertex(road.Item2, null);


                vertex1 = AddUniqueVertex(vertex1);
                vertex2 = AddUniqueVertex(vertex2);
                Edge edge = new Edge(vertex1, vertex2);
                Edges.Add(edge);

                vertex1.AddUniqueConnectedEdge(edge);
                vertex2.AddUniqueConnectedEdge(edge);
            }
        }

        public Vertex AddUniqueVertex(Vertex v)
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
    }
}
