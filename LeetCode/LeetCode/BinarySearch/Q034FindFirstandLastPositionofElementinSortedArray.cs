using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q034FindFirstandLastPositionofElementinSortedArray
    {
        //Search for a Range
        public Q034FindFirstandLastPositionofElementinSortedArray()
        {
           // var result = ob.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
        }


        /// <summary>
        /// 參考九章
        /// 先從左邊用二分搜尋來找
        /// 再從右邊用二分搜尋來找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange1(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { -1, -1 };

            int[] bound = new int[2];
            int start = 0;
            int end = nums.Length - 1;
            int mid = 0;

            //先處理左邊邊界
            while (start + 1 < end)
            {
                mid = start + (end - start) / 2;

                if (target == nums[mid])
                    end = mid;
                else if (nums[mid] < target)
                    start = mid;
                else
                    end = mid;
            }

            if (target == nums[start])
                bound[0] = start;
            else if (target == nums[end])
                bound[0] = end;
            else
                return new int[] { -1, -1 };

            start = 0;
            end = nums.Length - 1;

            //在處理右邊邊界
            while (start + 1 < end)
            {
                mid = start + (end - start) / 2;
                if (nums[mid] == target)
                    start = mid;
                else if (nums[mid] < target)
                    start = mid;
                else
                    end = mid;
            }

            if (nums[end] == target)
                bound[1] = end;
            else if (nums[start] == target)
                bound[1] = start;
            else
                return new int[] { -1, -1 };

            return bound;
        }

        //public int[] SearchRange2(int[] nums, int target)
        //{
        //    int[] bound = { -1, -1 };
        //    if (nums == null || nums.Length == 0)
        //        return bound;

        //    helperBinarySearch(nums, target, 0, nums.Length, 0, bound);
        //    helperBinarySearch(nums, target, 0, nums.Length, 1, bound);
        //    return bound;
        //}

        //private void helperBinarySearch(int[] nums, int target, int start, int end, int setPosition, int[] bound)
        //{
        //    while(start+1< end)
        //    {
        //        int mid = start + (end - start) / 2;

        //        if (nums[mid] == target)
        //            if (setPosition == 0)
        //                end = mid;
        //            else
        //                start = mid;
        //        else if (nums[mid] < target)
        //            start = mid;
        //        else
        //            end = mid;
        //    }

        //    if (nums[setPosition == 0 ? start : end] == target)
        //        bound[setPosition] = setPosition == 0 ? start : end;
        //    else if (nums[setPosition == 0 ? end : start] == target)
        //        bound[setPosition] = setPosition == 0 ? end : start;
        //    else
        //    {
        //        bound[0] = -1;
        //        bound[1] = -1;
        //    }
        //}

        /// <summary>
        /// 自己寫的
        /// 只有做左半邊二分法
        /// 右邊直接用+的去找
        /// 如果重複的量很多，效能會很差
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { -1, -1 };

            int[] result = new int[2];
            int start = 0;
            int end = nums.Length - 1;

            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;

                if (target == nums[mid])
                    end = mid;
                else if (nums[mid] < target)
                    start = mid;
                else
                    end = mid;
            }

            if (target == nums[start])
                result[0] = start;
            else if (target == nums[end])
            {
                result[0] = end;
                start = end;
            }
            else
                return new int[] { -1, -1 };

            while (start < nums.Length && nums[start] == target)
            {
                result[1] = start;
                start++;
            }
            return result;
        }

    }
}
