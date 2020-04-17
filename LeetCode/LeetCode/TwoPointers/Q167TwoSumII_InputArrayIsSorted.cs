using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.TwoPointers
{
    public class Q167TwoSumII_InputArrayIsSorted
    {
        public Q167TwoSumII_InputArrayIsSorted()
        {
            //  var result = ob.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
        }

        /// <summary>
        /// 自己寫的
        /// 裝指針寫法
        /// O(n)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int L = 0;
            int R = numbers.Length - 1;

            while (L < R)
            {
                if (numbers[L] + numbers[R] == target)
                    return new int[] { L + 1, R + 1 };
                else if (numbers[L] + numbers[R] < target)
                    L++;
                else
                    R--;
            }
            return null;
        }
    }
}
