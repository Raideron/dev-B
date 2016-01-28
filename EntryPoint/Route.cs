using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Route
    {
        //TODO change distance variable to method which gets from edges
        public double Distance { get; set; }
        public List<Edge> Edges { get; set; }

        public Route(double previousDistance, List<Edge> previousEdges)
        {
            Edges = new List<Edge>();
            if (previousEdges != null)
            {
                Edges.AddRange(previousEdges);
            }
            Distance = previousDistance;
        }
    }
}
