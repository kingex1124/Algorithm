using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q429N_aryTreeLevelOrderTraversal
    {
        public Q429N_aryTreeLevelOrderTraversal()
        {
            //Node node = new Node(1, new List<Node>() { new Node(3, new List<Node>() { new Node(5, new List<Node>()), new Node(6, new List<Node>()) }), new Node(2, new List<Node>()), new Node(4, new List<Node>()) });
            //var result = ob.LevelOrder(node);
        }

        /// <summary>
        /// 遞迴解法
        /// 學來的
        /// List<List<int>> 裡面有幾個元素，就表示有幾層
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            List<IList<int>> result = new List<IList<int>>();

            helper(root, 0, result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="level">層數-1</param>
        /// <param name="result">結果</param>
        private void helper(Node root, int level, List<IList<int>> result)
        {
            if (root == null)
                return;
            if (result.Count - 1 < level)
            {
                result.Add(new List<int>());
                result[level].Add(root.val);
            }
            else
                result[level].Add(root.val);

            if (root.children != null)
                foreach (var node in root.children)
                    helper(node, level + 1, result);
        }

        /// <summary>
        /// 參照解法4的作法，改良了List
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder4(Node root)
        {
            List<Node> arr = new List<Node>();
            arr.Add(root);

            List<IList<int>> result = new List<IList<int>>();

            while (arr.Count != 0)
            {
                //size 為當層的個數
                int size = arr.Count;
                List<int> list = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    Node cur = arr[0];
                    arr.RemoveAt(0);
                    if (cur == null)
                        continue;
                    list.Add(cur.val);
                    arr.AddRange(cur.children);
                }
                if (list.Count > 0)
                    result.Add(list);
            }
            return result;
        }

        /// <summary>
        /// 學來的
        /// 用queue寫 原理相同 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder3(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            List<IList<int>> result = new List<IList<int>>();

            while (queue.Count != 0)
            {
                //size 為當層的個數
                int size = queue.Count;
                List<int> list = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    Node cur = queue.Dequeue();
                    if (cur == null)
                        continue;
                    list.Add(cur.val);
                    foreach (var node in cur.children)
                        queue.Enqueue(node);
                }
                if (list.Count > 0)
                    result.Add(list);
            }
            return result;
        }


        /// <summary>
        /// 自己寫的，只用List
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder2(Node root)
        {
            if (root == null)
                return new List<IList<int>>();

            List<Node> arr = new List<Node>() { root, null };
            List<IList<int>> data = new List<IList<int>>() { new List<int>() };

            while (arr.Count > 1)
            {
                Node node = arr[0];
                arr.RemoveAt(0);
                if (node == null)
                {
                    arr.Add(null);
                    data.Add(new List<int>());
                }
                else
                {
                    foreach (var chidNode in node.children)
                        arr.Add(chidNode);

                    data[data.Count - 1].Add(node.val);
                }
            }
            return data;
        }

        /// <summary>
        /// 自己寫的解法
        /// time O(n)
        /// Spsce O(1)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder1(Node root)
        {
            if (root == null)
                return new List<IList<int>>();

            ArrayList arr = new ArrayList() { root, "s" };
            List<IList<int>> data = new List<IList<int>>() { new List<int>() };

            while (arr.Count > 1)
            {
                object node = arr[0];
                arr.RemoveAt(0);
                if (node.ToString() == "s")
                {
                    arr.Add("s");
                    data.Add(new List<int>());
                }
                else
                {
                    foreach (var chidNode in ((Node)node).children)
                        arr.Add(chidNode);

                    data[data.Count - 1].Add(((Node)node).val);
                }
            }
            return data;
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
