using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Rotate
{
    public class Q189RotateArray
    {
        public Q189RotateArray()
        {
            //int[] k = new int[] { 1, 2, 3 };
            //ob.Rotate(k, 2);
        }

        /// <summary>
        /// 學來的
        /// 相當於陣列向右邊移動K次
        /// time O(n)
        /// space O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || nums.Length == 1)
                return;

            k %= nums.Length;

            //三步驟翻轉，順序反過來走
            Reversed(nums, 0, nums.Length - 1);
            Reversed(nums, 0, k - 1);
            Reversed(nums, k, nums.Length - 1);
        }

        public void Reversed(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start++] = nums[end];
                nums[end--] = temp;
            }
        }

        /// <summary>
        /// 學來的
        /// time O(n)
        /// space O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate1(int[] nums, int k)
        {
            int[] temp = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
                temp[(i + k) % nums.Length] = nums[i];

            for (int i = 0; i < nums.Length; i++)
                nums[i] = temp[i];
        }
    }
}
