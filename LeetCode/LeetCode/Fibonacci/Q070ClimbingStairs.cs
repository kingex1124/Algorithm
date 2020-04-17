using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Fibonacci
{
    public class Q070ClimbingStairs
    {
        /// <summary>
        /// 同Fibonacci Number
        /// n=1,2,3,4,5,6
        /// 對應 1,2,3,5,8,13 種走法[可重復](Fibonacci Number)
        /// </summary>
        public Q070ClimbingStairs()
        {
            //var result = ob.ClimbStairs(8);
        }

        public Func<int, int> Function;

        /// <summary>
        /// 遞迴優化解 O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            int N = n + 1;
            Dictionary<int, int> cache = new Dictionary<int, int>();
            Function = (o) =>
            {
                if (cache.ContainsKey(o))
                    return cache[o];
                cache[o] = SlowFib(o);
                return cache[o];
            };
            return Function(N);
        }

        public int SlowFib(int n)
        {
            if (n < 2)
                return n;
            return Function(n - 1) + Function(n - 2);
        }

        /// <summary>
        /// O(2^n) 遞迴慢速解法
        /// time limit 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs2(int n)
        {
            int N = n + 1;
            if (N < 2)
                return N;
            return ClimbStairs2(n - 1) + ClimbStairs2(n - 2);
        }

        /// <summary>
        /// 迭代解法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs3(int n)
        {
            int N = n + 1;
            List<int> result = new List<int>() { 0, 1 };
            for (int i = 2; i <= N; i++)
                result.Add(result[i - 1] + result[i - 2]);
            return result[N];
        }

        /// <summary>
        /// 套子集合模板
        /// time limit(跑太久)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs1(int n)
        {
            int result = 0;
            List<int> step = new List<int>() { 1, 2 };
            helper(n, step, 0, new List<int>(), ref result);
            return result;
        }

        public void helper(int n, List<int> step, int sum, List<int> subSet, ref int result)
        {
            if (sum == n)
            {
                result++;
                return;
            }
            else if (sum > n)
                return;

            for (int i = 0; i < 2; i++)
            {
                subSet.Add(step[i]);
                sum += step[i];
                helper(n, step, sum, subSet, ref result);
                subSet.RemoveAt(subSet.Count - 1);
                sum -= step[i];
            }
        }
    }
}
