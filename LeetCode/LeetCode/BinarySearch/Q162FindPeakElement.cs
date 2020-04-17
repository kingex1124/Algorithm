using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q162FindPeakElement
    {
        public Q162FindPeakElement()
        {

        }

        /// <summary>
        /// 學來的，同852
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            int start = 0;
            int end = nums.Length - 1;

            while (start < end)
            {
                int mid = start + (end - start) / 2;
                //局部順逆判斷
                if (nums[mid] < nums[mid + 1])
                    start = mid + 1;
                else
                    end = mid;
            }

            return end;
        }

        /// <summary>
        /// 學來的遞迴寫法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement1(int[] nums)
        {
            return search(nums, 0, nums.Length - 1);
        }

        public int search(int[] num,int start ,int end)
        {
            if (start == end)
                return start;

            int mid = start + (end - start) / 2;

            if (num[mid] <= num[mid + 1])
                return search(num, mid + 1, end);
            else
                return search(num, start, mid);
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement2(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                    return i;
            }
            return nums.Length - 1;
        }
    }
}
