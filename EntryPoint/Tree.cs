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

        /// <summary>
        /// Returns a list of vectors within the specified range
        /// </summary>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        /// <param name="level">depth of the tree, when calling this value is ussually 1</param>
        /// <param name="root">can be left null for the root of the tree</param>
        /// <returns></returns>
        public List<Vector2> findRange(double xMin, double xMax, double yMin, double yMax, int level, Node root)
        {
            List<Vector2> returnValue = new List<Vector2>();
            if (root == null)
            {
                root = tree[0];
            }

            double xOrYRoot;
            double xOrYLeftChild;
            double xOrYRightChild;
            double xOrYMin;
            double xOrYMax;
            if (level % 2 != 0)
            {
                xOrYRoot = root.building.X;
                xOrYLeftChild = root.left.building.X;
                xOrYRightChild = root.right.building.X;
                xOrYMin = xMin;
                xOrYMax = xMax;
            }
            else
            {
                xOrYRoot = root.building.Y;
                xOrYLeftChild = root.left.building.Y;
                xOrYRightChild = root.right.building.Y;
                xOrYMin = yMin;
                xOrYMax = yMax;
            }

            if (xOrYRoot >= xOrYMin && xOrYRoot <= xOrYMax)
            {
                returnValue.Add(root.building);

                if (root.left != null)
                {
                    returnValue.AddRange(findRange(xMin, xMax, yMin, yMax, level++, root.left));
                }
                if (root.right != null)
                {
                    returnValue.AddRange(findRange(xMin, xMax, yMin, yMax, level++, root.right));
                }
            }



            return returnValue;
        }

        public void insert(Node root, Node newBuilding, int level)
        {
            //Node newNode = new Node(building);
            //tree.Add(newNode);
            if (tree.Count == 0)
            {
                tree.Add(newBuilding);
                return;
            }
            if (root == null)
            {
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
