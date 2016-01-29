using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class TreeNode
    {
        public Vector2 building { get; set; }
        //public int level { get; set; }
        public TreeNode root { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }

        public TreeNode(Vector2 newBuilding)
        {
            building = newBuilding;
        }
    }
}
