using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Lintcode.Tree.BinaryTree
{
    public class Q596MinimumSubtree
    {
        public Q596MinimumSubtree()
        {
            //TreeNode testdata = new TreeNode(1)
            //{
            //    left = new TreeNode(-5) { left = new TreeNode(1), right = new TreeNode(2) },
            //    right = new TreeNode(2) { left = new TreeNode(-4), right = new TreeNode(-5) }
            //};

            //var result = ob.FindSubtree2(testdata);
        }

        private TreeNode subtree = null;
        private int subtreeSum = int.MaxValue;

        /// <summary>
        /// 九章的解法1
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode FindSubtree(TreeNode root)
        {
            helper(root);
            return subtree;
        }

        public int helper(TreeNode root)
        {
            if (root == null)
                return 0;

            int sum = helper(root.left) + helper(root.right) + root.val;

            if (sum <= subtreeSum)
            {
                subtreeSum = sum;
                subtree = root;
            }

            return sum;
        }

        public class ResultType
        {
            public TreeNode minSubTree;
            public int sum;
            public int minSum;
            public ResultType(TreeNode minSubTree, int sum)
            {
                this.minSubTree = minSubTree;
                this.sum = sum;            
            }
            public ResultType(TreeNode minSubTree, int sum, int minSum)
            {
                this.minSubTree = minSubTree;
                this.sum = sum;
                this.minSum = minSum;
            }
        }

        /// <summary>
        /// 九章解法2
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode FindSubtree1(TreeNode root)
        {
            ResultType result = helper1(root);
            return result.minSubTree;
        }

        public ResultType helper1(TreeNode node)
        {
            if (node == null)
                return new ResultType(null, 0, int.MaxValue);

            ResultType left = helper1(node.left);
            ResultType right = helper1(node.right);

            ResultType result = new ResultType(
                node,
                left.sum + right.sum + node.val,
                left.sum + right.sum + node.val);

            if (left.minSum <= result.minSum)
            {
                result.minSum = left.minSum;
                result.minSubTree = left.minSubTree;
            }

            if (right.minSum <= result.minSum)
            {
                result.minSum = right.minSum;
                result.minSubTree = right.minSubTree;
            }
            return result;
        }

        /// <summary>
        /// 自己改良的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode FindSubtree2(TreeNode root)
        {
            ResultType result = new ResultType(null, int.MaxValue);
            helper2(root, ref result);
            return result.minSubTree;
        }

        public ResultType helper2(TreeNode node,ref ResultType result)
        {
            if (node == null)
                return new ResultType(null, 0);

            ResultType left = helper2(node.left,ref result);
            ResultType right = helper2(node.right,ref result);

            ResultType current = new ResultType(
                node,
                left.sum + right.sum + node.val);

            if (result == null || current.sum < result.sum)
                result = current;

            return current;
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
