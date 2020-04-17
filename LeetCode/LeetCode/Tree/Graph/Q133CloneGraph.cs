using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch
{
    public class Q133CloneGraph
    {
        public Q133CloneGraph()
        {
            //Node pr = new Node(1, new List<Node>());
            //Node to = new Node(2, new List<Node>());
            //Node fo = new Node(4, new List<Node>());
            //Node tr = new Node(3, new List<Node>());

            //pr.neighbors.Add(to);
            //pr.neighbors.Add(fo);

            //to.neighbors.Add(pr);
            //to.neighbors.Add(tr);

            //tr.neighbors.Add(to);
            //tr.neighbors.Add(fo);

            //fo.neighbors.Add(tr);
            //fo.neighbors.Add(pr);

            //var result = ob.CloneGraph(pr);
        }

        #region BFS

        /// <summary>
        /// 學來的
        /// BFS
        /// O(n)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph3(Node node)
        {
            if (node == null)
                return null;

            Node clone = new Node(node.val, new List<Node>());

            Dictionary<int, Node> map = new Dictionary<int, Node>();
            //add first node
            map.Add(clone.val, clone);
            //to store **original** nodes need to be visited
            Queue<Node> queue = new Queue<Node>();
            //add first **original** node to queue
            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                //search first node in the queue
                Node n = queue.Dequeue();
                foreach (var item in n.neighbors)
                {
                    //add to map and queue if this node hasn't been searched before
                    if (!map.ContainsKey(item.val))
                    {
                        map.Add(item.val, new Node(item.val, new List<Node>()));
                        queue.Enqueue(item);
                    }
                    //add neighbor to new created nodes
                    map[n.val].neighbors.Add(map[item.val]);
                }
            }
            return clone;
        }

        #endregion

        #region DFS

        /// <summary>
        /// 學來的
        /// 解法都差不多
        /// DFS
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph2(Node node)
        {
            Dictionary<int, Node> map = new Dictionary<int, Node>();
            return DFS(node, map);
        }

        private Node DFS(Node node, Dictionary<int, Node> map)
        {
            if (node == null) return null;
            if (map.ContainsKey(node.val)) return map[node.val];
            Node clone = new Node(node.val, new List<Node>());
            map.Add(node.val, clone);
            foreach (var item in node.neighbors)
                clone.neighbors.Add(DFS(item, map));
            return clone;
        }

        /// <summary>
        /// 同CloneGraph解法
        /// 只是把它簡化成一個方法
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph1(Node node)
        {
            if (node == null)
                return null;

            if (map.ContainsKey(node.val))
                return map[node.val];

            Node clone = new Node(node.val, new List<Node>());
            map.Add(node.val, clone);
            foreach (var neighbor in node.neighbors)
                clone.neighbors.Add(CloneGraph(neighbor));
            return clone;
        }

        private Dictionary<int, Node> map = new Dictionary<int, Node>();
        //題目給的是無限延伸的樹
        /// <summary>
        /// 學來的解法1
        /// DFS
        /// O(n)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph(Node node)
        {
            return Clone(node);
        }

        private Node Clone(Node node)
        {
            if (node == null)
                return null;

            if (map.ContainsKey(node.val))
                return map[node.val];

            Node clone = new Node(node.val, new List<Node>());
            map.Add(clone.val, clone);
            foreach (var neighbor in node.neighbors)
                clone.neighbors.Add(Clone(neighbor));

            return clone;
        }

        #endregion

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node() { }
            public Node(int _val, IList<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
    }
}
