using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q094BinaryTreeInorderTraversal
    {
        public Q094BinaryTreeInorderTraversal()
        {

        }

        /// <summary>
        /// 九章
        /// 迭代解法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal3(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;
            
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || stack.Count != 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                result.Add(cur.val);
                cur = cur.right;
            }
            return result;
        }

        /// <summary>
        /// 遞迴解法2
        /// 分治法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal2(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            IList<int> left = InorderTraversal2(root.left);
            IList<int> right = InorderTraversal2(root.right);

            result.AddRange(left);
            result.Add(root.val);
            result.AddRange(right);

            return result;
        }

        /// <summary>
        /// 遞迴解法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal1(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;
            traverse(root, result);
            return result;
        }

        private void traverse(TreeNode root, List<int> result)
        {
            if (root == null)
                return;

            traverse(root.left, result);
            result.Add(root.val);
            traverse(root.right, result);
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
