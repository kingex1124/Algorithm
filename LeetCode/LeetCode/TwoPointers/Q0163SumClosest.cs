using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q0163SumClosest
    {
        public Q0163SumClosest()
        {
            // var result = ob.ThreeSumClosest(new int[] { -1, 2, 1, -4 },1);
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest1(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[nums.Length - 1];
            Array.Sort(nums);
            //外圍指針
            for (int i = 0; i < nums.Length; i++)
            {
                int start = i + 1;
                int end = nums.Length - 1;
                while (start < end)
                {
                    int sum = nums[i] + nums[start] + nums[end];
                    if (sum > target)
                        end--;
                    else
                        start++;
                    //取最短距離
                    if (Math.Abs(sum - target) < Math.Abs(result - target))
                        result = sum;
                }
            }
            return result;
        }

        /// <summary>
        /// 陣列裡面挑三個數字相加，取"總和"最接近target的數字(最短距離)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            int result = 0;
            int resultTemp = int.MaxValue;

            int i, start, end;
            nums = nums.OrderBy(o => o).ToArray();
            int n = nums.Length;
            int d = 0;
            for (i = 0; i + 2 < n; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                //每圈重置
                end = n - 1;
                start = i + 1;
                while (start < end)
                {
                    int sum = nums[i] + nums[start] + nums[end];

                    if (sum == target)
                        return target;
                    else if (sum > target)
                    {
                        end--;
                        while (start < end && nums[end] == nums[end + 1]) end--;
                    }
                    else
                    {
                        start++;
                        while (start < end && nums[start] == nums[start - 1]) start++;
                    }
                    d = Math.Abs(target - sum);
                    if (d < resultTemp)
                    {
                        resultTemp = d;
                        result = sum;
                    }
                }
            }
            return result;
        }
    }
}
