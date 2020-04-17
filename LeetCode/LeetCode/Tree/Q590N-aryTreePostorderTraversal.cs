using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q590N_aryTreePostorderTraversal
    {
        public Q590N_aryTreePostorderTraversal()
        {

        }

        /// <summary>
        /// 遞迴解法
        /// O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder2(Node root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            helper(root, result);
            return result;
        }

        public void helper(Node root,List<int> result)
        {
            if (root == null)
                return;
            foreach (var child in root.children)
                helper(child, result);

            result.Add(root.val);
        }

        /// <summary>
        /// 用Stack寫
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
                result.Insert(0,node.val);
                foreach (var child in node.children)
                    stack.Push(child);
            }
            return result;
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder(Node root)
        {
            List<Node> arr = new List<Node>() { root };
            List<int> result = new List<int>();
            if (root == null)
                return result;
            while (arr.Count != 0)
            {
                Node node = arr[0];
                arr.RemoveAt(0);
                result.Insert(0, node.val);
                foreach (var chi in node.children)
                    arr.Insert(0, chi);
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
