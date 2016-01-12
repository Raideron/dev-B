using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Tree
    {
        public List<Node> tree = new List<Node>();
        public int rootIndex;

        public void insert(Node root, Node newBuilding, int level)
        {
            //Node newNode = new Node(building);
            //tree.Add(newNode);
            if (tree.Count == 0)
            {
                tree.Add(newBuilding);
                return;
            }
            if (root == null) {
                root = tree.ElementAt(0);
            }

            if (level % 2 != 0)
            {
                if (newBuilding.building.X < root.building.X)
                {
                    if (canInsert(root.left, newBuilding, level))
                    {
                        return;
                    }
                }
                else
                {
                    if (canInsert(root.right, newBuilding, level))
                    {
                        return;
                    }
                }
            }
            else
            {
                if (newBuilding.building.Y < root.building.Y)
                {
                    if (canInsert(root.left, newBuilding, level))
                    {
                        return;
                    }
                }
                else
                {
                    if (canInsert(root.right, newBuilding, level))
                    {
                        return;
                    }
                }
            }

        }

        private bool canInsert(Node child, Node newNode, int level)
        {
            if (child == null)
            {
                child = newNode;
                return true;
            }
            else
            {
                insert(child, newNode, level++);
                return false;
            }
        }
    }
}
