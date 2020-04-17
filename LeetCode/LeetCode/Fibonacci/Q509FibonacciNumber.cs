using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Fibonacci
{
    public class Q509FibonacciNumber
    {
        public Q509FibonacciNumber()
        {
            //var result = ob.Memoize(6);
        }

        #region 學來的遞迴優化解

        /// <summary>
        /// 改用List的寫法
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int Memoize2(int N)
        {
            List<int> cache = new List<int>() { 0 };
            function = (n) =>
            {
                if (n <= cache.Count - 1)
                    return cache[n];

                int result = SlowFib(n);
                cache.Add(result);
                return result;
            };

            return function(N);
        }

        Func<int, int> function;

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int Memoize(int N)
        {
            Dictionary<int, int> cache = new Dictionary<int, int>();
            function = (n) =>
            {
                if (cache.ContainsKey(n))
                    return cache[n];

                int result = SlowFib(n);
                cache[n] = result;
                return result;
            };

            return function(N);
        }

        public int SlowFib(int N)
        {
            if (N < 2)
                return N;

            return function(N - 1) + function(N - 2);
        }

        #endregion

        #region 改良學來的1(遞迴優化解)

        Dictionary<int, int> cache1 = new Dictionary<int, int>();
        public int Memoize1(int N)
        {
            if (cache1.ContainsKey(N))
                return cache1[N];

            int result = SlowFib1(N);
            cache1[N] = result;
            return result;
        }

        public int SlowFib1(int N)
        {
            if (N < 2)
                return N;

            return Memoize1(N - 1) + Memoize1(N - 2);
        }

        #endregion

        #region 學來的迭代解法

        /// <summary>
        /// 學來的 跌帶解法
        /// O(n)
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int Fib(int N)
        {
            List<int> result = new List<int>() { 0, 1 };
            for (int i = 2; i <= N; i++)
                result.Add(result[i - 1] + result[i - 2]);
            return result[N];
        }

        #endregion

        #region 自己寫的

        /// <summary>
        /// 自己寫的
        /// O(2^n)
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int Fib1(int N)
        {
            if (N == 0)
                return 0;
            else if (N == 1)
                return 1;

            return Fib1(N - 1) + Fib1(N - 2);
        }

        #endregion

    }
}
