using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q033SearchinRotatedSortedArray
    {
        /// <summary>
        /// 題目為 排序陣列 旋轉一次後 查詢
        /// </summary>
        public Q033SearchinRotatedSortedArray()
        {
            // var result = ob.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3);
        }

        /// <summary>
        /// 參考網路上後自己在修改的
        /// Time O(logn)
        /// space O(1)
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
                int mid = start + (end - start) / 2;
                if (nums[mid] == target)
                    return mid;
                //用頭跟中間比大小來判斷是不是順向，是的話繼續，不是的話比另外一段是否為順向
                //旋轉一次 只會出現一次大小亂序
                if (nums[start] <= nums[mid])
                {
                    if (nums[start] <= target && target < nums[mid])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else if (nums[mid] < nums[end])
                {
                    if (nums[mid] < target && target <= nums[end])
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 參考網路上的
        /// 改成遞迴寫法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search1(int[] nums, int target)
        {
            return helpSearch(nums, target, 0, nums.Length - 1);
        }

        public int helpSearch(int[] nums, int target, int start, int end)
        {
            if (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                    return mid;

                if (nums[start] <= nums[mid])
                {
                    if (nums[start] <= target && target < nums[mid])
                        return helpSearch(nums, target, start, mid - 1);
                    else
                        return helpSearch(nums, target, mid + 1, end);
                }
                else if (nums[mid] < nums[end])
                {
                    if (nums[mid] < target && target <= nums[end])
                        return helpSearch(nums, target, mid + 1, end);
                    else
                        return helpSearch(nums, target, start, mid - 1);
                }
            }
            return -1;
        }

        /// <summary>
        /// 九章解法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search2(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int start = 0;
            int end = nums.Length - 1;
            
            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[start] < nums[mid])
                {
                    if (nums[start] <= target && target <= nums[mid])
                        end = mid;
                    else
                        start = mid;
                }
                else
                {
                    if (nums[mid] <= target && target <= nums[end])
                        start = mid;
                    else
                        end = mid;
                }
            }

            if (nums[start] == target)
                return start;
            if (nums[end] == target)
                return end;
            return -1;
        }
    }
}
