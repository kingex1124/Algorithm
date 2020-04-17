using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q0153Sum
    {
        public Q0153Sum()
        {
            //var result = ob.ThreeSum(new int[] {3, 0, -2, -1, 1, 2});
            //var result = ob.ThreeSum(new int[] {-2, 0, 1, 1, 2});
            //var result = ob.ThreeSum(new int[] {-1, 0, 1, 2, -1, -4});
            //var result = ob.ThreeSum(new int[] { 3, -9, 3, 9, -6, -1, -2, 8, 6, -7, -14, -15, -7, 5, 2, -7, -4, 2, -12, -7, -1, -2, 1, -15, -13, -4, 0, -9, -11, 7, 4, 7, 13, 14, -7, -8, -1, -2, 7, -10, -2, 1, -10, 6, -9, -1, 14, 2, -13, 9, 10, -7, -8, -4, -14, -5, -1, 1, 1, 4, -15, 13, -12, 13, 12, -11, 12, -12, 2, -3, -7, -14, 13, -9, 7, -11, 5, -1, -2, -1, -7, -7, 0, -7, -4, 1, 3, 3, 9, 11, 14, 10, 1, -13, 8, -9, 13, -2, -6, 1, 10, -5, -6, 0, 1, 8, 4, 13, 14, 9, -2, -15, -13 });

        }

        /// <summary>
        /// 學來的（重要　記下來）
        /// Time Ｏ(n^2)
        /// space O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int low = i + 1;
                    int high = nums.Length - 1;
                    int sum = 0 - nums[i];
                    while (low < high)
                    {
                        if (nums[low] + nums[high] == sum)
                        {
                            result.Add(new List<int>() { nums[i], nums[low], nums[high] });
                            //重復的時候
                            while (low < high && nums[low] == nums[low + 1])
                                low++;
                            while (low < high && nums[high] == nums[high - 1])
                                high--;
                            low++;
                            high--;
                        }
                        else if (nums[low] + nums[high] < sum)
                            low++;
                        else
                            high--;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 九章寫法
        /// 雙指針
        /// 同上面
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum3(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
                return results;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                int left = i + 1;
                int right = nums.Length - 1;
                int target = -nums[i];

                TwoSum(nums, left, right, target, results);
            }
            return results;
        }

        private void TwoSum(int[] nums, int left, int right, int target, List<IList<int>> results)
        {
            while (left < right)
            {
                if (nums[left] + nums[right] == target)
                {
                    results.Add(new List<int>() { -target, nums[left], nums[right] });
                    left++;
                    left--;

                    while (left < right && nums[left] == nums[left++])
                        left++;
                    while (left < right && nums[right] == nums[right--])
                        right--;
                }
                else if (nums[left] + nums[right] < target)
                    left++;
                else
                    right--;
            }
        }

        /// <summary>
        /// 參考網路版+修改
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int i, j, k;
            nums = nums.OrderBy(o => o).ToArray();
            int n = nums.Length;
            for (i = 0; i + 2 < n; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                //因為剩下的都是正數
                if (nums[i] + nums[i + 1] + nums[i + 2] > 0)
                    continue;
                //最小的加上兩個最大的小於零 無解
                if (nums[i] + nums[n - 2] + nums[n - 1] < 0)
                    continue;
                //每圈重置
                k = n - 1;
                j = i + 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        j++;
                        k--;
                        while (j < k && nums[j] == nums[j - 1]) j++;
                        while (j < k && nums[k] == nums[k + 1]) k--;
                    }
                    else if (0 < sum)
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
            return result;
        }

        /// <summary>
        /// 低效能timeOut版
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum1(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int i, j, k;
            int n = nums.Length;
            nums = nums.OrderBy(o => o).ToArray();
            for (i = 0; i + 2 < n; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                for (j = i + 1; j < n; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    for (k = j + 1; k < n; k++)
                    {
                        if (k > j + 1 && nums[k] == nums[k - 1]) continue;
                        if (-nums[i] == nums[j] + nums[k])
                            result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                    }
                }
            }
            return result;
        }
    }
}
