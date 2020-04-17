using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q637AverageOfLevelsInBinaryTree
    {
        public Q637AverageOfLevelsInBinaryTree()
        {

        }

        /// <summary>
        /// Queue寫法
        /// BFT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> result = new List<double>();
            if (root == null)
                return result;

            Queue<TreeNode> arr = new Queue<TreeNode>();
            arr.Enqueue(root);

            while (arr.Count != 0)
            {
                int size = arr.Count;

                double sum = 0;
                for (int i = 0; i < size; i++)
                {
                    TreeNode cur = arr.Dequeue();

                    if (cur == null)
                        continue;
                    sum += cur.val;

                    if (cur.left != null)
                        arr.Enqueue(cur.left);
                    if (cur.right != null)
                        arr.Enqueue(cur.right);
                }
              
                result.Add(sum / size);
            }

            return result;
        }

        /// <summary>
        /// List寫法
        /// BFT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<double> AverageOfLevels1(TreeNode root)
        {
            List<double> result = new List<double>();
            if (root == null)
                return result;

            List<TreeNode> arr = new List<TreeNode>();
            arr.Add(root);

            while (arr.Count != 0)
            {
                int size = arr.Count;

                double sum = 0;
                for (int i = 0; i < size; i++)
                {
                    TreeNode cur = arr[0];
                    arr.RemoveAt(0);

                    if (cur == null)
                        continue;
                    sum += cur.val;

                    if (cur.left != null)
                        arr.Add(cur.left);
                    if (cur.right != null)
                        arr.Add(cur.right);
                }
           
                result.Add(sum / size);
            }

            return result;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
