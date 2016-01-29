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
        //public List<Node> tree = new List<Node>();
        public TreeNode root = null;

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
        public List<Vector2> findRange(double xMin, double xMax, double yMin, double yMax, int level, TreeNode root)
        {
            List<Vector2> returnValue = new List<Vector2>();
            if (root == null)
            {
                root = this.root;
            }

            double xOrYRoot;
            double xOrYMin;
            double xOrYMax;
            if (level % 2 != 0)
            {
                xOrYRoot = root.building.X;
                xOrYMin = xMin;
                xOrYMax = xMax;
            }
            else
            {
                xOrYRoot = root.building.Y;
                xOrYMin = yMin;
                xOrYMax = yMax;
            }

            if (xOrYMin <= xOrYRoot && xOrYRoot <= xOrYMax)
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
            else if (xOrYRoot < xOrYMin && root.right != null)
            {
                returnValue.AddRange(findRange(xMin, xMax, yMin, yMax, level++, root.right));
            }
            else if (xOrYMax < xOrYRoot && root.left != null)
            {
                returnValue.AddRange(findRange(xMin, xMax, yMin, yMax, level++, root.left));
            }

            return returnValue;
        }

        /// <summary>
        /// inserts a new node into the tree
        /// </summary>
        /// <param name="root">should be null when calling</param>
        /// <param name="newBuilding"></param>
        /// <param name="level">should be one when calling</param>
        public void insert(TreeNode root, TreeNode newBuilding, int level)
        {
            if (this.root == null)
            {
                this.root = newBuilding;
                return;
            }
            if (root == null)
            {
                root = newBuilding;
                return;
            }

            double xOrYRoot;
            double xOrYNew;
            if (level % 2 != 0)
            {
                xOrYRoot = root.building.X;
                xOrYNew = newBuilding.building.X;
            }
            else
            {
                xOrYRoot = root.building.Y;
                xOrYNew = newBuilding.building.Y;
            }

            if (xOrYNew < xOrYRoot)
            {
                if (root.left == null)
                {
                    root.left = newBuilding;
                }
                else
                {
                    insert(root.left, newBuilding, level++);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = newBuilding;
                }
                else
                {
                    insert(root.right, newBuilding, level++);
                }
            }
            newBuilding.root = root;
        }
    }
}
