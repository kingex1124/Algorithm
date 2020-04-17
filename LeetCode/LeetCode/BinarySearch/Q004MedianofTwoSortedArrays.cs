using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q004MedianofTwoSortedArrays
    {
        public Q004MedianofTwoSortedArrays()
        {

        }

        /// <summary>
        /// 花花
        /// 看起來像是 組成一排  拿左邊的中位數 跟右邊的中位數 比較 要差不多大小
        /// 就會成為合併的中位數
        // Found maxLeftX <= minRightY,maxLeftY <= minRightX
        // else if maxLeftX > minRightY move forwords left in X
        // else move forwords right in X
        /// O(log(n+m))
        /// Space Complax O(1)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays1(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;
            // Make sure n1 < n2
            if (n1 > n2)
                return FindMedianSortedArrays1(nums2, nums1);
            // 合併後的 左中位數 (n1 n2 構成的元素)
            int k = (n1 + n2 + 1) / 2;

            //搜索範圍
            int left = 0;
            int right = n1;

            while (left < right)
            {
                int m1 = left + (right - left) / 2;
                int m2 = k - m1;
                //如果是小於 表示第一個數組的元素不夠多
                //就把 l 移到m1+1 
                //如果太大 就把 r 移到m1

                //a[m1]是第一个数组里面第一个没被取到的，
                //b[m2-1]是第二个数组里面最后一个被取到的，
                //如果a[m1]<b[m2-1],
                //说明第一个数组里面取少了
                if (nums1[m1] < nums2[m2 - 1])
                    left = m1 + 1; //多取一個
                else
                    right = m1;
            }

            int mm1 = left;
            int mm2 = k - left;

            // 左中位數       判斷有沒有小於最小長度  左邊的要-1
            int c1 = Math.Max(mm1 <= 0 ? int.MinValue : nums1[mm1 - 1],
                mm2 <= 0 ? int.MinValue : nums2[mm2 - 1]);

            if ((n1 + n2) % 2 == 1)
                return c1;

            // 右中位數       判斷有沒有超過最大長度 右邊的不用-1
            int c2 = Math.Min(mm1 >= n1 ? int.MaxValue : nums1[mm1],
                mm2 >= n2 ? int.MaxValue : nums2[mm2]);

            return (c1 + c2) * 0.5;
        }

        /// <summary>
        /// 自己寫的 
        /// O(n+m)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null && nums2 == null)
                return 0;

            int n1 = nums1.Length;
            int n2 = nums2.Length;
            if (nums1 == null)
            {
                if (n2 % 2 == 1)
                    return nums2[n2 / 2 + 1];
                else
                    return (nums2[n2 / 2 - 1] + nums2[n2 / 2 + 1 - 1]) * 0.5;
            }
            if (nums2 == null)
            {
                if (n1 % 2 == 1)
                    return nums1[n1 / 2 + 1];
                else
                    return (nums1[n1 / 2 - 1] + nums1[n1 / 2 - 1]) * 0.5;
            }
            int[] temp = new int[n1 + n2];
            int l1 = n1 - 1;
            int l2 = n2 - 1;
            int index = n1 + n2 - 1;
            while (index >= 0)
            {
                if (l1 < 0)
                    temp[index--] = nums2[l2--];
                else if (l2 < 0)
                    temp[index--] = nums1[l1--];
                else if (nums1[l1] < nums2[l2])
                    temp[index--] = nums2[l2--];
                else
                    temp[index--] = nums1[l1--];
            }
            if (temp.Length % 2 == 1)
                return temp[temp.Length / 2];
            else
                return (temp[temp.Length / 2 - 1] + temp[temp.Length / 2 - 1 + 1]) * 0.5;

        }
    }
}
