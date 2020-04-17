using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q350IntersectionofTwoArraysII
    {
        public Q350IntersectionofTwoArraysII()
        {

        }

        /// <summary>
        /// 九章解法
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (map.ContainsKey(nums1[i]))
                    map[nums1[i]] += 1;
                else
                    map.Add(nums1[i], 1);
            }

            List<int> results = new List<int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                if (map.ContainsKey(nums2[i]) && map[nums2[i]] > 0)
                {
                    results.Add(nums2[i]);
                    map[nums2[i]] -= 1;
                }
            }

            int[] result = new int[results.Count];
            //for (int i = 0; i < results.Count; i++)
            //    result[i] = results[i];
            int index = 0;
            foreach (var num in results)
                result[index++] = num;

            return result;
        }
    }
}
