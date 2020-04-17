using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q0184Sum
    {
        public Q0184Sum()
        {
            //  var result = ob.FourSum(new int[] { -2, 0, 0, 3, 3, -1},5);
        }

        /// <summary>
        /// 學來的
        /// O(n^3)
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {

            IList<IList<int>> result = new List<IList<int>>();
            int i, j, k, m;
            nums = nums.OrderBy(o => o).ToArray();
            int n = nums.Length;
            for (i = 0; i + 3 < n; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                //因為剩下的都是正數
                if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 2] > target)
                    continue;
                //最小的加上兩個最大的小於零 無解
                if (nums[i] + nums[n - 3] + nums[n - 2] + nums[n - 1] < target)
                    continue;
                for (m = i + 1; m + 2 < n; m++)
                {
                    if (m > i + 1 && nums[m] == nums[m - 1])
                        continue;
                    //每圈重置
                    k = n - 1;
                    j = m + 1;
                    while (j < k)
                    {
                        int sum = nums[i] + nums[m] + nums[j] + nums[k];
                        if (sum == target)
                        {
                            result.Add(new List<int>() { nums[i], nums[m], nums[j], nums[k] });
                            j++;
                            k--;
                            while (j < k && nums[j] == nums[j - 1]) j++;
                            while (j < k && nums[k] == nums[k + 1]) k--;
                        }
                        else if (target < sum)
                        {
                            k--;
                            while (j < k && nums[k] == nums[k + 1]) k--;
                        }
                        else
                        {
                            j++;
                            while (j < k && nums[j] == nums[j - 1]) j++;
                        }
                    }
                }
            }
            return result;
        }
    }
}
