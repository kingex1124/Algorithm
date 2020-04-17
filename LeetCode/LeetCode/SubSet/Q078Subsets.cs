using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q078Subsets
    {
        public Q078Subsets()
        {
            //int[] nums = new[] { 1, 2, 3, 4 };
            //var resutl = ob.Subsets(nums);
        }

        #region 套模板的

        /// <summary>
        /// n(logn)+2^n
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>() { };
            List<int> tmp = new List<int>();
            //n(logn)
            Array.Sort(nums);
            helper(nums, 0, tmp, result);

            return result;
        }


        public void helper(int[] nums, int offSet, List<int> subSet, List<IList<int>> result)
        {
           
            result.Add(subSet.ToList());
            // Time complex 2^n
            for (int i = offSet; i < nums.Length; i++)
            {
                //過濾相同數字的情況
                if (i != offSet && nums[i] == nums[offSet])
                    continue;
                subSet.Add(nums[i]);
                helper(nums, i + 1, subSet, result);
                subSet.RemoveAt(subSet.Count - 1);
            }
        }

        #endregion

        #region 九章

        #region DFS

        public List<List<int>> SubSets(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();

            return result;
        }

        // Time complex 2^(n+1)
        // 1. 遞迴的定義
        // 以 subset 開頭的，配上 nums 以 index 開始的數所有組合放到 results 裡
        private void dfs(int[] nums,int index,List<int> subSet ,List<List<int>> result)
        {
            //3.遞迴的出口
            if(index == nums.Length)
            {
                result.Add(subSet.ToList());
                return;
            }

            // 2. 遞迴的拆解
            // (如何進入下一層)

            // 選了 nums[index]
            subSet.Add(nums[index]);
            dfs(nums, index + 1, subSet, result);

            // 不選 nums[index]
            subSet.RemoveAt(subSet.Count - 1);
            dfs(nums, index + 1, subSet, result);

        }

        #endregion

        #region 位元解法

        public List<List<int>> subsets(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            int n = nums.Length;
            Array.Sort(nums);

            // 1 << n is 2^n
            // each subset equals to an binary integer between 0 .. 2^n - 1
            // 0 -> 000 -> []
            // 1 -> 001 -> [1]
            // 2 -> 010 -> [2]
            // ..
            // 7 -> 111 -> [1,2,3]
            for (int i = 0; i < (1 << n); i++)
            {
                List<int> subset = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    // check whether the jth digit in i's binary representation is 1
                    if ((i & (1 << j)) != 0)
                    {
                        subset.Add(nums[j]);
                    }
                }
                result.Add(subset);
            }
            return result;
        }

        #endregion

        #endregion

        #region 自己想的
        /// <summary>
        /// 自己想的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets1(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>() { };

            nums = nums.OrderBy(o => o).ToArray();
            int len = nums.Length;
            foreach (var item in nums)
                result.Add(new List<int>() { item });

            for (int k = 0; k < result.Count - 1; k++)
            {
                int coun = result[k].Count;
                for (int j = 0; j < len; j++)
                {
                    if (result[k][coun - 1] == nums[len - 1])
                        continue;
                    if (result[k][coun - 1] < nums[j])
                    {
                        List<int> ad = new List<int>();
                        ad.AddRange(result[k]);
                        ad.Add(nums[j]);
                        result.Add(ad);
                    }
                }
            }

            result.Add(new List<int>());

            return result;
        }

        #endregion
    }
}
