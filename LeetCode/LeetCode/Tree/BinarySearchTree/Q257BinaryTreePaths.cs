using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q257BinaryTreePaths
    {
        public Q257BinaryTreePaths()
        {

        }

        /// <summary>
        /// 九章遞迴解法
        /// List DFT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths3(TreeNode root)
        {
            List<string> paths = new List<string>();

            if (root == null)
                return paths;

            IList<string> leftPath = BinaryTreePaths3(root.left);
            IList<string> rightPath = BinaryTreePaths3(root.right);

            //由下往上塞路徑
            foreach (var path in leftPath)
                paths.Add(root.val + "->" + path);

            foreach (var path in rightPath)
                paths.Add(root.val + "->" + path);

            if (paths.Count == 0)
                paths.Add("" + root.val);

            return paths;
        }


        /// <summary>
        /// 自己寫的 迭代解法
        /// Queue
        /// BFT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths2(TreeNode root)
        {
            List<string> result = new List<string>();

            if (root == null)
                return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            Queue<string> depths = new Queue<string>();

            queue.Enqueue(root);
            depths.Enqueue(root.val.ToString());

            while (queue.Count != 0)
            {
                TreeNode node = queue.Dequeue();
                string path = depths.Dequeue();

                //在往下都是空的就表示走到最深了
                if (node.left == null && node.right == null)
                    result.Add(path);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    depths.Enqueue(path + "->" + node.left.val.ToString());
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    depths.Enqueue(path + "->" + node.right.val.ToString());
                }
            }

            return result;
        }

        /// <summary>
        /// 自己寫的遞迴寫法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths1(TreeNode root)
        {
            List<string> result = new List<string>();

            if (root != null)
                helper(root, root.val.ToString(), result);

            return result;
        }

        public void helper(TreeNode node, string path, List<string> result)
        {
            if (node.left == null && node.right == null)
                result.Add(path);
            if (node.left != null)
                helper(node.left, path + "->" + node.left.val, result);
            if (node.right != null)
                helper(node.right, path + "->" + node.right.val, result);
        }


        /// <summary>
        /// 自己解的 跌代解法
        /// Sack
        /// DFT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> result = new List<string>();

            if (root == null)
                return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<string> depths = new Stack<string>();

            stack.Push(root);
            depths.Push(root.val.ToString());

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                string path = depths.Pop();

                //在往下都是空的就表示走到最深了
                if (node.left == null && node.right == null)
                    result.Add(path);
                if (node.right != null)
                {
                    stack.Push(node.right);
                    depths.Push(path + "->" + node.right.val.ToString());
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                    depths.Push(path + "->" + node.left.val.ToString());
                }
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
