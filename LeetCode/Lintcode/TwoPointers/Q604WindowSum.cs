using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Lintcode.TwoPointers
{
    public class Q604WindowSum
    {
        public Q604WindowSum()
        {
            // var result = ob.WinSum(new int[] { 1, 2, 7, 8, 5 }, 3);
        }

        /// <summary>
        /// 網路上學來的
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] WinSum1(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k < 0)
                return new int[0];

            int[] sums = new int[nums.Length - k + 1];

            for (int i = 0; i < k; i++)
                sums[0] += nums[i];

            // 扣掉前一個數字 然後加上第三位數字 往下推移
            for (int i = 1; i < sums.Length; i++)
                sums[i] = sums[i - 1] - nums[i - 1] + nums[i - 1 + k];

            return sums;
        }

        /// <summary>
        /// 自己寫的
        /// O(N)
        /// chunk解法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] WinSum(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k < 0)
                return new int[0];
            
            List<List<int>> tmp = new List<List<int>>();
            for (int i = 0; i + k <= nums.Length && i < nums.Length; i++)
            {
                for (int j = i; j < i + k && j < nums.Length; j++)
                {
                    List<int> last = tmp.Any() ? tmp.Last() : null;
                    if (last == null || last.Count == k)
                        tmp.Add(new List<int>() { nums[j] });
                    else
                        last.Add(nums[j]);
                }
            }

            List<int> result = new List<int>();
            foreach (var item in tmp)
                result.Add(item.Sum());

            return result.ToArray();
        }
    }
}
