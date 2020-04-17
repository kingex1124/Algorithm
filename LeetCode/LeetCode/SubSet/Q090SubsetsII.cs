using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q090SubsetsII
    {
        public Q090SubsetsII()
        {
            //int[] nums = new[] { 1, 2, 2 };
        
            //var result = ob.SubsetsWithDup(nums);
        }

        /// <summary>
        /// 用模板解
        /// TimeComplex n(logn)+2^n
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>() { };
            // n(logn)
            Array.Sort(nums);

            helper(nums, 0, new List<int>(), result);
            return result;
        }

        /// <summary>
        /// 2^n
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="offset"></param>
        /// <param name="subSet"></param>
        /// <param name="result"></param>
        public void helper(int[] nums, int offset, List<int> subSet, List<IList<int>> result)
        {
            result.Add(subSet.ToList());

            for (int i = offset; i < nums.Length; i++)
            {
                //if (i != offset && (nums[i] == nums[offset] || nums[i] == nums[i - 1]))
                if (i > offset && nums[i] == nums[i - 1])
                    continue;

                subSet.Add(nums[i]);
                helper(nums, i + 1, subSet, result);
                subSet.RemoveAt(subSet.Count - 1);
            }
        }

    }
}
