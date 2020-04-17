using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q153FindMinimuminRotatedSortedArray
    {
        public Q153FindMinimuminRotatedSortedArray()
        {
            // var result = ob.FindMin(new int[] { 5, 1, 2, 3, 4 });
        }


        /// <summary>
        /// 九章解法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int start = 0;
            int end = nums.Length - 1;
            //存尾端的值
            int target = nums[end];

            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;
                //小於尾端的值,表示中間值為順的，大於的話表示逆的排序
                if (nums[mid] <= target)
                    end = mid;
                else
                    start = mid;
            }

            return Math.Min(nums[start], nums[end]);
        }

        /// <summary>
        /// 參考在調整的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin1(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int start = 0;
            int end = nums.Length - 1;
            int mid = 0;

            while (start <= end)
            {
                mid = (start + end) / 2;

                //由小到大 大在到小 那就是小的那個是最小的
                if (mid > 0 && nums[mid] < nums[mid - 1])
                    return nums[mid];

                //左邊正常 右邊逆向 表示右邊被翻轉過 所以左邊的頭換掉
                if (nums[start] <= nums[mid] && nums[end] < nums[mid])
                {
                    start = mid + 1;
                }
                else
                    end = mid - 1;
            }
            return nums[start];
        }

        /// <summary>
        /// 參考網路上的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            //當下一個比前一個小=>表示逆的 拿下一個跟頭比 
            //只有在第一次碰到逆的時候，那個值會是最小的 比方說 6,7,1,2,3
            //1,2,3,4,5
            for (int i = 0; i < nums.Length - 1; i++)
                if (nums[i + 1] < nums[i])
                    return nums[i + 1];

            return nums[0];
        }
    }
}
