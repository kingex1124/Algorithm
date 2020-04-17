using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q035SearchInsertPosition
    {
        /// <summary>
        /// 這題不會回傳-1 但要回傳附近的index
        /// </summary>
        public Q035SearchInsertPosition()
        {
            //  var result = ob.SearchInsert(new int[] { 1, 3, 5, 7 }, 6);
        }

        /// <summary>
        /// 模板
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            int start = 0;
            int end = nums.Length - 1;
            if (target < nums[start])
                return start;
            if (target > nums[end])
                return end + 1;

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

            return start;
        }
    }
}
