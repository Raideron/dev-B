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
        public double TotalDistanceFromStart { get; set; }
        public bool Visited { get; set; }
        public List<Vertex> ConnectedVerteces { get; set; }
    }
}
