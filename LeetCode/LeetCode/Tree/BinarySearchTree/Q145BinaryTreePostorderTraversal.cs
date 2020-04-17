using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q145BinaryTreePostorderTraversal
    {
        public Q145BinaryTreePostorderTraversal()
        {

        }

        /// <summary>
        /// 自己寫的跌代解
        /// 用List
        /// 稍微優化版
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal5(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;
            List<TreeNode> arr = new List<TreeNode>() { root };
            List<int> tmp = new List<int>();
            TreeNode node = root;

            while (arr.Count != 0)
            {
                if (node != null)
                {
                    tmp.Add(node.val);
                    if (node.left != null)
                        arr.Insert(0, node.left);
                    node = node.right;
                }
                else
                {
                    node = arr[0];
                    arr.RemoveAt(0);
                }
            }

            while (tmp.Count != 0)
            {
                result.Add(tmp[tmp.Count - 1]);
                tmp.RemoveAt(tmp.Count - 1);
            }

            return result;
        }

        /// <summary>
        /// 自己寫的跌代解
        /// 用List
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal4(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;
            List<TreeNode> arr = new List<TreeNode>() { root };
            List<int> tmp = new List<int>();
            while (arr.Count != 0)
            {
                TreeNode node = arr[0];
                arr.RemoveAt(0);
                tmp.Add(node.val);
                if (node.left != null)
                    arr.Insert(0, node.left);
                if (node.right != null)
                    arr.Insert(0, node.right);
            }

            while (tmp.Count != 0)
            {
                result.Add(tmp[tmp.Count - 1]);
                tmp.RemoveAt(tmp.Count - 1);
            }

            return result;
        }

        /// <summary>
        /// 跌代解2
        /// 用stack 
        /// 稍微優化版
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal3(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<int> output = new Stack<int>();
            stack.Push(root);

            TreeNode curr = root;
            while (stack.Count != 0)
            {
                if (curr != null)
                {
                    output.Push(curr.val);
                    if (curr.left != null)
                        stack.Push(curr.left);
                    curr = curr.right;
                }
                else
                    curr = stack.Pop();
            }

            while (output.Count != 0)
                result.Add(output.Pop());

            return result;
        }

        /// <summary>
        /// 跌代解1
        /// Stack用
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal2(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<int> output = new Stack<int>();
            stack.Push(root);

            TreeNode curr = root;
            while (stack.Count != 0)
            {
                curr = stack.Pop();
                output.Push(curr.val);
                if (curr.left != null)
                    stack.Push(curr.left);
                if (curr.right != null)
                    stack.Push(curr.right);
            }

            while (output.Count != 0)
                result.Add(output.Pop());

            return result;
        }

        /// <summary>
        /// 遞迴解2
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal1(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            IList<int> left = PostorderTraversal1(root.left);
            IList<int> right = PostorderTraversal1(root.right);

            result.AddRange(left);
            result.AddRange(right);
            result.Add(root.val);

            return result;
        }

        /// <summary>
        /// 遞迴解
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
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

            traverse(root.right, result);
            result.Add(root.val);
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
