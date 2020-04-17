using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Lintcode.Tree.Graph
{
    public class Q127TopologicalSorting
    {
        public Q127TopologicalSorting()
        {
            List<DirectedGraphNode> prm = new List<DirectedGraphNode>();
            prm.Add(new DirectedGraphNode(0) { neighbors = new List<DirectedGraphNode>() { new DirectedGraphNode(1), new DirectedGraphNode(2), new DirectedGraphNode(3), new DirectedGraphNode(4) } });
            prm.Add(new DirectedGraphNode(1) { neighbors = new List<DirectedGraphNode>() { new DirectedGraphNode(3), new DirectedGraphNode(4) } });
            prm.Add(new DirectedGraphNode(2) { neighbors = new List<DirectedGraphNode>() { new DirectedGraphNode(1), new DirectedGraphNode(4) } });
            prm.Add(new DirectedGraphNode(3) { neighbors = new List<DirectedGraphNode>() { new DirectedGraphNode(4) } });
            prm.Add(new DirectedGraphNode(4));
            var result = TopSort(prm);
        }

        public List<DirectedGraphNode> TopSort(List<DirectedGraphNode> graph)
        {
            List<DirectedGraphNode> result = new List<DirectedGraphNode>();
            Dictionary<DirectedGraphNode, int> map = new Dictionary<DirectedGraphNode, int>();
            //先把孩子的那層通通加進去(第二階層)
            foreach (DirectedGraphNode node in graph)
            {
                foreach (DirectedGraphNode neighbor in node.neighbors)
                {
                    if (map.ContainsKey(neighbor))
                        map[neighbor] = map[neighbor] + 1;
                    else
                        map.Add(neighbor, 1);
                }
            }
            Queue<DirectedGraphNode> q = new Queue<DirectedGraphNode>();
            //先把父層的通通加到結果中(非孩子曾相同的)
            foreach (DirectedGraphNode node in graph)
            {
                if (!map.ContainsKey(node))
                {
                    q.Enqueue(node);
                    result.Add(node);
                }
            }
            while (q.Count != 0)
            {
                DirectedGraphNode node = q.Dequeue();
                //把所有孩子層的通通加到結果
                foreach (DirectedGraphNode n in node.neighbors)
                {
                    if (map.ContainsKey(n))
                        map[n] = map[n] - 1;
                    if (map[n] == 0)
                    {
                        result.Add(n);
                        //用來取孩子的孩子，所以再次存入Q
                        q.Enqueue(n);
                    }
                }
            }
            return result;
        }

        public class DirectedGraphNode
        {
            public int label;
            public List<DirectedGraphNode> neighbors;
            public DirectedGraphNode(int x)
            {
                label = x;
                neighbors = new List<DirectedGraphNode>();
            }
        }
    }
}
