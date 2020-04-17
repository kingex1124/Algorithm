using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Palindrome
{
    public class Q283MoveZeroes
    {
        public Q283MoveZeroes()
        {
            //   ob.MoveZeroes(new int[] { 0, 1, 0, 3, 12 });
        }

        /// <summary>
        /// 九章解法
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes2(int[] nums)
        {
            int left = 0;
            int right = 0;
            while (right < nums.Length)
            {
                if (nums[right] != 0)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                    left++;
                }
                right++;
            }
        }

        /// <summary>
        /// 學來的
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes1(int[] nums)
        {
            int notZeroCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                    nums[notZeroCount++] = nums[i];
            }
            for (int i = notZeroCount; i < nums.Length; i++)
                nums[i] = 0;
        }

        /// <summary>
        /// 參考後改良的
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int zeroCount = 0;
            int[] result = new int[nums.Length];
            int countResult = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    zeroCount++;
                else
                    result[countResult++] = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
                nums[i] = result[i];
        }
    }
}
