using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q349IntersectionofTwoArrays
    {
        public Q349IntersectionofTwoArrays()
        {

        }

        /// <summary>
        /// 九章解法
        /// version 3: sort & binary search
        /// O(m*log(m))
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection3(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return null;
            HashSet<int> set = new HashSet<int>();
            Array.Sort(nums1);
            for (int i = 0; i < nums2.Length; i++)
            {
                if (set.Contains(nums2[i]))
                    continue;
                if (binarySearch(nums1, nums2[i]))
                    set.Add(nums2[i]);
            }

            int[] result = new int[set.Count];
            int index = 0;
            foreach (var num in set)
                result[index++] = num;

            return result;
        }

        private bool binarySearch(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return false;

            int start = 0;
            int end = nums.Length - 1;
            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target)
                    return true;
                if (nums[mid] < target)
                    start = mid;
                else
                    end = mid;
            }
            if (nums[start] == target)
                return true;
            if (nums[end] == target)
                return true;

            return false;
        }
        /// <summary>
        /// 九章解法
        /// version 2: hash map
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return null;

            HashSet<int> hash = new HashSet<int>();
            for (int i = 0; i < nums1.Length; i++)
                hash.Add(nums1[i]);

            HashSet<int> resultHash = new HashSet<int>();
            for (int i = 0; i < nums2.Length; i++)
                if (hash.Contains(nums2[i]) && !resultHash.Contains(nums2[i]))
                    resultHash.Add(nums2[i]);

            int size = resultHash.Count;
            int[] result = new int[size];
            int index = 0;
            foreach (var num in resultHash)
                result[index++] = num;

            return result;
        }

        /// <summary>
        /// 九章解法
        /// version 1: sort & merge
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection1(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            int i = 0;
            int j = 0;
            int[] tmp = new int[nums1.Length];
            int index = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    //第一個元素 || 前一個元素是否跟當下的相同
                    if (index == 0 || tmp[index - 1] != nums1[i])
                        tmp[index++] = nums1[i];
                    i++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                    i++;
                else
                    j++;
            }
            int[] result = new int[index];

            for (int k = 0; k < index; k++)
                result[k] = tmp[k];

            return result;
        }

    }
}
