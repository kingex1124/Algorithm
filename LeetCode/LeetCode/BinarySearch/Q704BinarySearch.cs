using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q704BinarySearch
    {
        public Q704BinarySearch()
        {

        }

        /// <summary>
        /// 套模板
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (end + start) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (target < nums[mid])
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            return -1;
        }
    }
}
