using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Node
    {
        public Vector2 building { get; set; }
        //public int level { get; set; }
        public Node root { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(Vector2 newBuilding)
        {
            building = newBuilding;
        }
    }
}
