using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Lintcode.Tree.BFS
{
    public class Q178GraphValidTree
    {
        public Q178GraphValidTree()
        {
            //int[][] pr = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 1, 4 } };
            //int[][] pr1 = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 1, 3 }, new int[] { 1, 4 } };

            //var result = ob.ValidTree5(5, pr);
        }

        #region DFS解法

        // 2-0-1-4
        //   |
        //   3
        //0:1,2,3
        //1:0,4
        //2:0
        //3:0
        //4:1
        /// <summary>
        /// 學來的
        /// DFS解法
        /// Time O(edges * nodes)
        /// Space O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool ValidTree1(int n, int[][] edges)
        {
            //if (n == 0)
            //    return false;
            ////邊數等於節點數-1 (不然有可能會形成環)
            //if (edges.Length != n - 1)
            //    return false;

            //點和邊的組合 組合成 List<List<int>>的形式
            List<List<int>> graph = BuildGraph(n, edges);

            HashSet<int> visited = new HashSet<int>();

            if (!HelperDFS(graph, visited, 0, -1))
                return false;

            return visited.Count == graph.Count;
        }

        /// <summary>
        /// 建立 Graph
        /// Time O(nodes)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public List<List<int>> BuildGraph(int n, int[][] edges)
        {
            //點和邊的組合 組合成 List<List<int>>的形式
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
                graph.Add(new List<int>());
            //建立邊，把點一個個加入 O(nodes)
            for (int i = 0; i < edges.Length; i++)
            {
                //取0 跟0位置相關的是1
                graph[edges[i][0]].Add(edges[i][1]);
                //取1 跟1位置相關的是0
                graph[edges[i][1]].Add(edges[i][0]);
            }

            return graph;
        }

        /// <summary>
        /// 找每個小孩的最近的父節點的方法
        /// Time O(edges)
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="visited">已找過的小孩</param>
        /// <param name="curr">小孩(指標位置)</param>
        /// <param name="parent">父節點</param>
        /// <returns></returns>
        private bool HelperDFS(List<List<int>> graph, HashSet<int> visited, int curr, int parent)
        {
            //如果同一個小孩重復找了，表示形成了環
            if (visited.Contains(curr))
                return false;
            visited.Add(curr);

            //取一組出來判斷
            foreach (var child in graph[curr])
            {
                //如果與父節點相同則跳過
                if (child == parent)
                    continue;
                //不同的話往下找父節點
                if (!HelperDFS(graph, visited, child, curr))
                    return false;
            }
            return true;
        }

        #endregion

        #region BFS解法1

        /// <summary>
        /// 學來的
        /// 此處的BFS 是指 graph 一行一行的跑
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool ValidTree2(int n, int[][] edges)
        {
            //if (n == 0)
            //    return false;
            ////邊數等於節點數-1 (不然有可能會形成環)
            //if (edges.Length != n - 1)
            //    return false;

            //點和邊的組合 組合成 List<List<int>>的形式
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
                graph.Add(new List<int>());
            //建立邊，把點一個個加入 O(nodes)
            for (int i = 0; i < edges.Length; i++)
            {
                //取0 跟0位置相關的是1
                graph[edges[i][0]].Add(edges[i][1]);
                //取1 跟1位置相關的是0
                graph[edges[i][1]].Add(edges[i][0]);
            }

            bool[] visited = new bool[n];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count != 0)
            {
                int top = queue.Dequeue();
                //如果出來有重復的 就會是 true 表示出現環
                if (visited[top])
                    return false;

                visited[top] = true;

                foreach (var child in graph[top])
                {
                    if (!visited[child])
                        queue.Enqueue(child);
                }
            }

            foreach (var v in visited)
            {
                if (!v)
                    return false;
            }

            return true;
        }

        #endregion

        #region BFS解法2 用HashSet

        /// <summary>
        /// 學來的
        /// 此處的BFS 是指 graph 一行一行的跑
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool ValidTree3(int n, int[][] edges)
        {
            if (n == 0)
                return false;
            //邊數等於節點數-1 (不然有可能會形成環)
            if (edges.Length != n - 1)
                return false;

            //點和邊的組合 組合成 List<List<int>>的形式
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
                graph.Add(new List<int>());
            //建立邊，把點一個個加入 O(nodes)
            for (int i = 0; i < edges.Length; i++)
            {
                //取0 跟0位置相關的是1
                graph[edges[i][0]].Add(edges[i][1]);
                //取1 跟1位置相關的是0
                graph[edges[i][1]].Add(edges[i][0]);
            }

            //BFS
            HashSet<int> visited = new HashSet<int>();
            visited.Add(0);

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count != 0)
            {
                int node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                        continue;
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return visited.Count == n;
        }

        /// <summary>
        /// 九章的BFS解法，同上面方式
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool ValidTree4(int n, int[][] edges)
        {
            if (n == 0)
                return false;

            if (edges.Length != n - 1)
                return false;

            Dictionary<int, HashSet<int>> graph = InitializeGraph(n, edges);

            //BFS
            Queue<int> queue = new Queue<int>();
            HashSet<int> hash = new HashSet<int>();

            queue.Enqueue(0);
            hash.Add(0);

            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                foreach (var neighbor in graph[node])
                {
                    if (hash.Contains(neighbor))
                        continue;
                    hash.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
            return hash.Count == n;
        }

        private Dictionary<int, HashSet<int>> InitializeGraph(int n, int[][] edges)
        {
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++)
                graph.Add(i, new HashSet<int>());
            for (int i = 0; i < edges.Length; i++)
            {
                int u = edges[i][0];
                int v = edges[i][1];
                graph[u].Add(v);
                graph[v].Add(u);
            }
            return graph;
        }

        #endregion

        #region Union Find 解法

        #region UnionFind

        public class UnionFind
        {
            int[] paraent;
            int count;

            public UnionFind(int x)
            {
                paraent = new int[x];
                count = x;
                for (int i = 0; i < x; i++)
                    paraent[i] = i;
            }

            public void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);
                if (rootX != rootY)
                {
                    paraent[rootX] = rootY;
                    count--;
                }
            }

            public int Find(int x)
            {
                if (paraent[x] == x)
                    return paraent[x];
                return paraent[x] = Find(paraent[x]);
            }

            public int Query()
            {
                return count;
            }
        }

        #endregion

        /// <summary>
        ///  Full-length union-find, not necessary
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool ValidTree5(int n, int[][] edges)
        {
            //if (n == 0)
            //    return false;
            ////邊數等於節點數-1 (不然有可能會形成環)
            //if (edges.Length != n - 1)
            //    return false;

            // No node, false
            if (n == 0)
                return false;

            // 1 Node without edges, true
            if (n == 1 && (edges == null || edges.Length == 0))
                return true;

            // >= 2 nodes but no edges, false;
            if (edges == null || edges.Length == 0 || edges[0] == null || edges[0].Length == 0)
                return false;

            UnionFind unionFind = new UnionFind(n);
            for (int i = 0; i < edges.Length; i++)
            {
                int x = edges[i][0];
                int y = edges[i][1];
                //一開始每個點的根節點都是自己 所以不會相接，途中如果有相接，表示形成了環
                if (unionFind.Find(x) == unionFind.Find(y))
                    return false;
                unionFind.Union(x, y);
            }

            //結果只會剩下一個集合
            return unionFind.Query() == 1;
        }

        #region Union-Find 簡化寫法

        /// <summary>
        /// Union-Find
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool ValidTree7(int n, int[][] edges)
        {
            if (edges.Length != n - 1)
                return false;

            int[] roots = new int[n];
            for (int i = 0; i < n; i++)
                roots[i] = i;

            for (int i = 0; i < edges.Length; i++)
            {
                int rootX = root(roots, edges[i][0]);
                int rootY = root(roots, edges[i][1]);
                if (rootX == rootY)
                    return false;
                roots[rootY] = rootX;
            }

            return true;

        }

        public int root(int[] roots, int id)
        {
            if (id == roots[id])
                return id;
            return root(roots, roots[id]);
        }

        #endregion

        #endregion

    }
}
