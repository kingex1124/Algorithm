using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q081SearchinRotatedSortedArrayII
    {
        public Q081SearchinRotatedSortedArrayII()
        {

        }

        /// <summary>
        /// 參考網路上的
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return false;

            int start = 0;
            int end = nums.Length - 1;
            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;

                if (nums[start] < nums[mid]) //頭到中間 順向
                {
                    if (target < nums[mid] && nums[start] <= target) //不含中間端點 在區間內
                        end = mid; // 所以直接取中間的值 不用-1
                    else
                        start = mid;
                }
                else if (nums[start] > nums[mid])//頭到中間 逆向
                {
                    //頭到中間 逆向的話，那就拿剩下的那塊來判斷 剩下的有一部分會是順向
                    if (target > nums[mid] && target <= nums[end]) //不含中間端點 在區間內
                        start = mid;
                    else
                        end = mid;
                }
                else
                    start++;
            }
            if (nums[start] == target || nums[end] == target)
                return true;
            return false;
        }
    }
}
