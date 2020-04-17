using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.Graph
{
    public class Q200NumberofIslands
    {
        public Q200NumberofIslands()
        {
            //char[][] pr = new char[][] { new char[] { '1', '1', '1', '1', '0' }, new char[] { '1', '1', '0', '1', '0' }, new char[] { '1', '1', '0', '0', '0' }, new char[] { '0', '0', '0', '0', '0' } };

            //var result = ob.NumIslands(pr);
        }

        /// <summary>
        /// 學來的 DFS解法
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
                return 0;

            int rowLen = grid.Length;
            int colLen = grid[0].Length;
            int result = 0;

            for (int y = 0; y < rowLen; y++)
            {
                for (int x = 0; x < colLen; x++)
                {
                    if (grid[y][x] == '1')
                    {
                        result++;
                        DFS(grid, y, x, rowLen, colLen);
                    }
                }
            }
            return result;
        }

        private void DFS(char[][] grid, int y, int x, int rowLen, int colLen)
        {
            //超過，或為水 就反回
            if (x < 0 || y < 0 || y >= rowLen || x >= colLen || grid[y][x] == '0')
                return;

            //把陸地變回水
            grid[y][x] = '0';
            //遞迴的訪問左右上下 找到所有的1 把它全部變成0
            DFS(grid, y, x + 1, rowLen, colLen);
            DFS(grid, y, x - 1, rowLen, colLen);
            DFS(grid, y + 1, x, rowLen, colLen);
            DFS(grid, y - 1, x, rowLen, colLen);
        }

        /// <summary>
        /// 學來改良的BFS解法
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands1(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
                return 0;

            int rowLen = grid.Length;
            int colLen = grid[0].Length;
            int result = 0;

            for (int y = 0; y < rowLen; y++)
            {
                for (int x = 0; x < colLen; x++)
                {
                    if (grid[y][x] == '1')
                    {
                        result++;
                        BFS(grid, y, x, rowLen, colLen);
                    }
                }
            }
            return result;
        }

        private void BFS(char[][] grid, int y, int x, int rowLen, int colLen)
        {
            //各種方向移動的參數
            int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

            grid[y][x] = '0';

            Queue<int[]> queue = new Queue<int[]>();

            int[] curr = new int[] { x, y };
            queue.Enqueue(curr);

            while (queue.Count != 0)
            {
                curr = queue.Dequeue();
                foreach (var dir in dirs)
                {
                    int i = curr[0] + dir[0];
                    int j = curr[1] + dir[1];

                    if (i < 0 || j < 0 || j >= rowLen || i >= colLen || grid[j][i] == '0')
                        continue;
                    grid[j][i] = '0';
                    //每個變成水的點，要再查一次上下左右，看看有沒有島嶼
                    queue.Enqueue(new int[] { i, j });
                }
            }
        }

        /// <summary>
        /// 參考九章改良的
        /// 遍查集解法
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands2(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
                return 0;

            int rowLen = grid.Length;
            int colLen = grid[0].Length;

            UnionFind uf = new UnionFind(rowLen * colLen);

            //各種方向移動的參數
            int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

            int total = 0;
            //把所有為島的總點數存入遍查集的 count
            //每合併一個集合會扣1個島位置
            for (int i = 0; i < rowLen; ++i)
                for (int j = 0; j < colLen; ++j)
                    if (grid[i][j] == '1')
                        total++;

            uf.count = total;
            for (int y = 0; y < rowLen; y++)
            {
                for (int x = 0; x < colLen; x++)
                {
                    if (grid[y][x] == '1')
                    {
                        //把島的上下左右 為島的點 透過遍查集 合併 傳入唯一代碼位置 (例如 4*5 = 0~19的代碼位置)
                        if (y > 0 && grid[y - 1][x] == '1')
                            uf.Union(y * colLen + x, (y - 1) * colLen + x);
                        if (y < rowLen - 1 && grid[y + 1][x] == '1')
                            uf.Union(y * colLen + x, (y + 1) * colLen + x);
                        if (x > 0 && grid[y][x - 1] == '1')
                            uf.Union(y * colLen + x, y * colLen + x - 1);
                        if (x < colLen - 1 && grid[y][x + 1] == '1')
                            uf.Union(y * colLen + x, y * colLen + x + 1);
                    }
                }
            }
            return uf.Query();
        }

        #region UnionFind
        public class UnionFind
        {
            Dictionary<int, int> paraent = new Dictionary<int, int>();
            public int count = 0;

            public UnionFind(int x)
            {
                for (int i = 0; i < x; i++)
                {
                    if (!paraent.ContainsKey(i))
                        paraent.Add(i, i);
                }
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

    }
}
