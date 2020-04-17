using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.SortArray
{
    public class Q088MergeSortedArray
    {
        public Q088MergeSortedArray()
        {
            // ob.Merge(new int[] { 1,2,3,0,0,0 }, 3, new int[] { 2,5,6 }, 3);
        }

        /// <summary>
        /// 辦參考半自寫
        /// O(n)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int index = m + n - 1;
            int n1 = m - 1;
            int n2 = n - 1;

            while (index >= 0)
            {
                if (n1 < 0)
                    nums1[index--] = nums2[n2--];
                else if (n2 < 0)
                    nums1[index--] = nums1[n1--];
                else if (nums1[n1] < nums2[n2])
                    nums1[index--] = nums2[n2--];
                else
                    nums1[index--] = nums1[n1--];
            }
        }
        /// <summary>
        /// 九章解法
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, index = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[index--] = nums1[i--];
                }
                else
                {
                    nums1[index--] = nums2[j--];
                }
            }
            while (i >= 0)
            {
                nums1[index--] = nums1[i--];
            }
            while (j >= 0)
            {
                nums1[index--] = nums2[j--];
            }
        }
    }
}
