using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Lintcode.Tree.Graph
{
    public class Q605SequenceReconstruction
    {
        public Q605SequenceReconstruction()
        {

        //    [1]
        //[[],[]]
            int[][] pr = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 } };
            int[][] pr1 = new int[][] { new int[] { 1, 2 } };
            int[][] pr2 = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 3 } };
            int[][] pr3 = new int[][] { new int[] { 5, 2, 6, 3 }, new int[] { 4, 1, 5, 2 } };
            int[][] pr4 = new int[][] { new int[] { } };
            int[][] pr5 = new int[][] { new int[] { }, new int[] { } };
            var result = SequenceReconstruction1(new int[] { 1, 2, 3 }, pr);
            var result1 = SequenceReconstruction1(new int[] { 1, 2, 3 }, pr1);
            var result2 = SequenceReconstruction1(new int[] { 1, 2, 3 }, pr2);
            var result3 = SequenceReconstruction1(new int[] { 4, 1, 5, 2, 6, 3 }, pr3);
            var result4 = SequenceReconstruction1(new int[] { }, pr4);
            var result5 = SequenceReconstruction1(new int[] { 1 }, pr5);
        }

        /// <summary>
        /// 學來改良過的
        /// </summary>
        /// <param name="org"></param>
        /// <param name="seqs"></param>
        /// <returns></returns>
        public bool SequenceReconstruction1(int[] org, int[][] seqs)
        {
            if (org.Length == 0 && seqs[0].Length==0)
                return true;
            if (seqs == null || seqs.Length == 0 || seqs[0].Length == 0)
                return false;

            int n = org.Length;
            //-1表示去掉頭 因為後面頭會直接 continus
            int cnt = n - 1;

            int[] pos = new int[n + 1];
            int[] flags = new int[n + 1];      

            // key 跟 value 交換
            for (int i = 0; i < n; i++)
                pos[org[i]] = i;

            foreach (var seq in seqs)
            {
                for (int i = 0; i < seq.Length; i++)
                {
                    //超過範圍的都是失敗的
                    if (seq[i] < 0 || seq[i] > n)
                        return false;
                    if (i == 0)
                        continue;
                    //前一個值
                    int pre = seq[i - 1];
                    //當下的值
                    int cur = seq[i];

                    //前面是判斷該值是否已經被訪問過了
                    //後面是判斷前一個值+1是否會等於後面一個值
                    if (flags[cur] == 0 && pos[pre] + 1 == pos[cur])
                    {
                        //標記已經訪問
                        flags[cur] = 1;
                        cnt--;
                    }
                }
            }
            return cnt == 0;
        }

        /// <summary>
        /// 九章解的
        /// 拓樸排序
        /// </summary>
        /// <param name="org"></param>
        /// <param name="seqs"></param>
        /// <returns></returns>
        public bool SequenceReconstruction(int[] org, int[][] seqs)
        {
            // Write your code here
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            Dictionary<int, int> indegree = new Dictionary<int, int>();

            foreach (int num in org)
            {
                map.Add(num, new List<int>());
                indegree.Add(num, 0);
            }

            int n = org.Length;
            int count = 0;
            foreach (int[] seq in seqs)
            {
                count += seq.Length;
                if (seq.Length >= 1 && (seq[0] <= 0 || seq[0] > n))
                    return false;
                for (int i = 1; i < seq.Length; i++)
                {
                    if (seq[i] <= 0 || seq[i] > n)
                        return false;

                    if (map.ContainsKey(seq[i - 1]))
                    {
                        map[seq[i - 1]].Add(seq[i]);                      
                        indegree[seq[i]]++;            
                    }
                }
            }

            // case: [1], []
            if (count < n)
                return false;

            Queue<int> q = new Queue<int>();
            foreach (int key in indegree.Keys)
                if (indegree[key] == 0)
                    q.Enqueue(key);

            int cnt = 0;
            while (q.Count() == 1)
            {
                int ele = q.Dequeue();
                foreach (int next in map[ele])
                {
                    indegree[next]--;

                    if (indegree[next] == 0)
                        q.Enqueue(next);
                }
                if (ele != org[cnt])
                    return false;
                
                cnt++;
            }

            return cnt == org.Length;
        }
    }
}
