using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Fibonacci
{
    public class Q746MinCostClimbingStairs
    {
        public Q746MinCostClimbingStairs()
        {
            //var result = ob.MinCostClimbingStairs(new int[] { 0, 1, 1, 1 });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            int first = 0;
            int second = 0;
            for (int i = 0; i < cost.Length; i++)
            {
                //本次的加上兩種結果挑一個最小的加上去
                int current = cost[i] + Math.Min(first, second);
                //上回挑得結果放在first
                first = second;
                //此回挑的結果放在second
                second = current;
            }
            return Math.Min(first, second);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs1(int[] cost)
        {
            int[] dp = new int[cost.Length + 1];
            dp[0] = cost[0];
            dp[1] = cost[1];
            for (int i = 2; i < dp.Length; i++)
            {
                int cur = i == cost.Length ? 0 : cost[i];
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cur;
            }
            return dp[cost.Length];
        }

    }
}
