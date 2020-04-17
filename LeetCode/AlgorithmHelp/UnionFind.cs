using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.AlgorithmHelp
{
    public class UnionFind
    {
        /// <summary>
        /// 標註當前元素的父節點位置
        /// </summary>
        private int[] parent;

        /// <summary>
        /// 標註當前元素的層級樹
        /// </summary>
        private int[] rank;

        /// <summary>
        /// 並查集中的元素個數 
        /// </summary>
        private int size;

        public UnionFind(int size)
        {
            this.size = size;

            parent = new int[size];

            rank = new int[size];

            Initializer();
        }

        private void Initializer()
        {
            for (int i = 0; i < size; i++)
            {
                //初始化時，所有節點的父節點指向本身，所有的元素層級均為1
                parent[i] = i;
                rank[i] = 1;
            }
        }

        /// <summary>
        /// 尋找當前節點的根結點元素
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Find(int target)
        {
            if (target >= size)
                throw new Exception();
            if (target == parent[target])
                return parent[target];
            //拿本身的父節點，去找祖先(root)
            return Find(parent[target]);
            // 下方的寫法為 直接將孩子的父節點 存成祖先 下次就會直接對應到祖先
            // 與上面那行的差別在於 上面的是每次都要往上找祖先，透過父親往上找
            //return parent[target] = Find(parent[target]);
        }

        public void Union(int x,int y)
        {
            int xRoot = Find(x);
            int yRoot = Find(y);

            if (xRoot == yRoot)
                return;
            // x 所在的樹的高度比 y 所在樹的高度高，這時應該讓 y 的根節點元素接到 x 的根結點元素
            if (rank[xRoot] > rank[yRoot])
                parent[yRoot] = xRoot; // 此時樹的高度不變
            else if (rank[xRoot] < rank[yRoot])
                parent[xRoot] = yRoot; // 此時樹的高度不變
            else
            {
                //比方說兩個 rank 2的樹合併， 必有一個接在另一個的根底下
                //如此就會變成 rank 3
                parent[xRoot] = yRoot; // 此時樹的高度 + 1
                rank[xRoot] += 1;
            }
        }

        /// <summary>
        /// 判斷兩個節點是否相連
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool isConnected(int x , int y)
        {
            // 如果兩個節點的根節點一致，則表示這兩個節點是相連的
            return Find(x) == Find(y);
        }
    }

    public class UnionFindTestData
    {
        public UnionFindTestData()
        {
            int size = 10;

            // Step 1: init()
            UnionFind uf = new UnionFind(size);

            // Step 2: union()

            uf.Union(1, 2);
            uf.Union(3, 4);
            uf.Union(0, 9);
            uf.Union(4, 7);
            uf.Union(6, 5);
            uf.Union(5, 8);
            uf.Union(3, 9);
            uf.Union(1, 8);

            // Step 3: Find()

            Console.WriteLine(uf.Find(0));
            Console.WriteLine(uf.Find(1));
            Console.WriteLine(uf.Find(2));
            Console.WriteLine(uf.Find(3));
            Console.WriteLine(uf.Find(4));
            Console.WriteLine(uf.Find(5));
            Console.WriteLine(uf.Find(6));
            Console.WriteLine(uf.Find(7));
            Console.WriteLine(uf.Find(8));
            Console.WriteLine(uf.Find(9));

            // Step 4: isConnected
            Console.WriteLine(uf.isConnected(0,1));
            Console.WriteLine(uf.isConnected(1,2));
            Console.WriteLine(uf.isConnected(3,4));
            Console.WriteLine(uf.isConnected(5,6));
            Console.WriteLine(uf.isConnected(7,8));
            Console.WriteLine(uf.isConnected(8,9));
            Console.WriteLine(uf.isConnected(2,4));
            Console.WriteLine(uf.isConnected(3,5));
            Console.WriteLine(uf.isConnected(5,6));
            Console.WriteLine(uf.isConnected(7,9));
        }
    }

    #region UnionFind

    public class UnionFind1
    {
        Dictionary<int, int> paraent = new Dictionary<int, int>();
        int count;

        public UnionFind1(int[] x)
        {
            count = x.Length;

            foreach (var item in x)
            {
                if (!paraent.ContainsKey(item))
                    paraent.Add(item, item);
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
