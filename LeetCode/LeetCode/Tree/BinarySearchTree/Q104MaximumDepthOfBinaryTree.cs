using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q104MaximumDepthOfBinaryTree
    {
        public Q104MaximumDepthOfBinaryTree()
        {

        }

        private int depth;
        public int MaxDepth4(TreeNode root)
        {
            depth = 0;

            helper1(root, 1);

            return depth;
        }

        private void helper1(TreeNode node,int curtDepth)
        {
            if (node == null)
                return;

            if (curtDepth > depth)
                depth = curtDepth;

            helper1(node.left, curtDepth + 1);
            helper1(node.right, curtDepth + 1);
        }

        /// <summary>
        /// 學來的遞迴解法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth3(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + Math.Max(MaxDepth3(root.left), MaxDepth3(root.right));
        }


        /// <summary>
        /// stack 跌代解法
        /// 學來的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth2(TreeNode root)
        {
            if (root == null)
                return 0;

            int max = 1;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<int> depths = new Stack<int>();

            stack.Push(root);
            depths.Push(1);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                int depth = depths.Pop();

                //在往下都是空的就表示走到最深了
                if (node.left == null && node.right == null)
                    max = Math.Max(max, depth);
                if (node.right != null)
                {
                    stack.Push(node.right);
                    depths.Push(depth + 1);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                    depths.Push(depth + 1);
                }
            }

            return max;
        }

        int result = 1;
        /// <summary>
        /// 遞迴解法 自己寫的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            else
                helper(root, 1);
            return result;
        }

        /// <summary>
        /// 前序走法
        /// </summary>
        /// <param name="root"></param>
        /// <param name="depth"></param>
        public void helper(TreeNode root, int depth)
        {
            if (root == null)
                return;
            if (root.left != null)
            {
                if (depth + 1 > result)
                    result = depth + 1;
                helper(root.left, depth + 1);
            }
            if (root.right != null)
            {
                if (depth + 1 > result)
                    result = depth + 1;
                helper(root.right, depth + 1);
            }
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
