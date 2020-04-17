using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinaryTree
{
    public class Q110BalancedBinaryTree
    {
        public Q110BalancedBinaryTree()
        {

        }

        /// <summary>
        /// 解法二
        /// 九章
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced1(TreeNode root)
        {
            return Helper1(root).isBalanced;
        }

        public ResultType Helper1(TreeNode root)
        {
            if (root == null)
                return new ResultType(true, 0);

            ResultType left = Helper1(root.left);
            ResultType right = Helper1(root.right);

            if (!left.isBalanced || !right.isBalanced ||
                Math.Abs(left.maxDepth - right.maxDepth) > 1)
                return new ResultType(false, -1);

            return new ResultType(true, Math.Max(left.maxDepth, right.maxDepth) + 1);
        }

        public class ResultType
        {
            public bool isBalanced;
            public int maxDepth;
            public ResultType(bool isBalanced, int maxDepth)
            {
                this.isBalanced = isBalanced;
                this.maxDepth = maxDepth;
            }
        }

        /// <summary>
        /// 解法一 學來的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            return Helper(root) != -1;
        }


        private int Helper(TreeNode node)
        {
            if (node == null)
                return 0;

            int left = Helper(node.left);
            int right = Helper(node.right);

            if (left == -1 || right == -1 || Math.Abs(left - right) > 1)
                return -1;
            return Math.Max(left, right) + 1;
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
