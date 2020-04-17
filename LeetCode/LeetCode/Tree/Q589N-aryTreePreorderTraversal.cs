using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q589N_aryTreePreorderTraversal
    {
        public Q589N_aryTreePreorderTraversal()
        {

        }

        /// <summary>
        /// 遞迴解法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder2(Node root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            helper(root, result);
            return result;
        }
        public void helper(Node root, List<int> result)
        {
            if (root == null)
                return;

            result.Add(root.val);

            foreach (var child in root.children)
                helper(child, result);
        }

        /// <summary>
        /// stack寫法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder1(Node root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                Node node = stack.Pop();
                result.Add(node.val);
                for (int i = node.children.Count-1; i >= 0; i--)
                    stack.Push(node.children[i]);
            }
            return result;
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            List<Node> arr = new List<Node>() { root };
            List<int> result = new List<int>();
            if (root == null)
                return result;
            while (arr.Count != 0)
            {
                Node node = arr[0];
                arr.RemoveAt(0);
                result.Add(node.val);
                arr.InsertRange(0, node.children);
            }
            return result;
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }
            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }
}
