using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 陣列中找兩數相加的總和等於某個值，回傳陣列位置
    /// </summary>
    public class Q001TwoSum
    {
        public Q001TwoSum()
        {
            //代入範本
            //int[] nums = new int[] { 2, 7, 11, 15 };
            //int target = 9;
            //var result = ob.TwoSum2(nums, target);
        }



        /// <summary>
        /// 兩數總和
        /// O(n^2)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {

            int[] result = new int[] { };
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        result = new int[] { i, j };
                }
            }
            return result;
        }

        /// <summary>
        /// 參考別人的
        /// Hash解法
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numbers.ContainsKey(complement))
                    return new[] { numbers[complement], i };
                if (!numbers.ContainsKey(nums[i]))               
                numbers.Add(nums[i], i);
            }
            return null;
        }

        /// <summary>
        /// 學來的
        /// Hash解法
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum3(int[] nums, int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    result[1] = i;
                    result[0] = map[target - nums[i]];
                    return result;
                }
                if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], i);
            }
            return result;
        }

        /// <summary>
        /// 參考九章
        /// 雙指針寫法
        /// 左右兩邊靠近
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum4(int[] nums, int target)
        {
            pair[] number = new pair[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                number[i] = new pair(nums[i], i);

            Array.Sort(number, new ValueComparator());

            int L = 0;
            int R = nums.Length - 1;
            while (L < R)
            {
                if (number[L].GetValue() + number[R].GetValue() == target)
                {
                    int t1 = number[L].index;
                    int t2 = number[R].index;
                    int[] result = { Math.Min(t1, t2), Math.Max(t1, t2) };
                    return result;
                }
                if (number[L].GetValue() + number[R].GetValue() < target)
                    L++;
                else
                    R--;
            }
            int[] res = { };
            return res;
        }

        public class ValueComparator : Comparer<pair>
        {
            public override int Compare(pair o1, pair o2)
            {
                return o1.GetValue().CompareTo(o2.GetValue());
            }
        }

        public class pair
        {
            public int value;
            public int index;

            public pair(int value, int index)
            {
                this.value = value;
                this.index = index;
            }
            public int GetValue()
            {
                return this.value;
            }
        }
    }
}
