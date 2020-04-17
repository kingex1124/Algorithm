using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q144BinaryTreePreorderTraversal
    {
        public Q144BinaryTreePreorderTraversal()
        {

        }

        /// <summary>
        /// 九章解法
        /// 分治法
        /// 遞迴解
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal3(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            IList<int> left = PreorderTraversal(root.left);
            IList<int> right = PreorderTraversal(root.right);

            result.Add(root.val);
            result.AddRange(left);
            result.AddRange(right);

            return result;
        }

        /// <summary>
        /// 九章解法
        /// 學來的 Stack 解法
        /// 非遞迴
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal2(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();
            if (root == null)
                return result;

            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                result.Add(node.val);
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }
            return result;
        }

        /// <summary>
        /// Good
        /// 自己寫的分治法
        /// 同九章
        /// 遞迴解
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal1(TreeNode root)
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
            result.Add(root.val);
            traverse(root.left, result);
            traverse(root.right, result);
        }

        /// <summary>
        /// 自己寫的
        /// 非遞迴
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<TreeNode> arr = new List<TreeNode>() { root };
            List<int> result = new List<int>();
            if (root == null)
                return result;
            while (arr.Count != 0)
            {
                TreeNode node = arr[0];
                arr.RemoveAt(0);
                result.Add(node.val);
                if (node.right != null)
                    arr.Insert(0, node.right);
                if (node.left != null)
                    arr.Insert(0, node.left);
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
