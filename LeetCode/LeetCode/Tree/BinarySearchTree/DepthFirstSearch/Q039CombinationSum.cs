using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.DepthFirstSearch
{
    public class Q039CombinationSum
    {
        public Q039CombinationSum()
        {
            //int[] pr = new int[] { 2, 3, 6, 7 };
            //var result = ob.CombinationSum(pr, 7);
        }

        /// <summary>
        /// 自己寫的
        /// 子集合解法
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            Array.Sort(candidates);

            Helper(candidates, target, 0, 0, new List<int>(), result);

            return result;
        }

        private void Helper(int[] candidates, int target, int sum, int start, List<int> subSet, List<IList<int>> result)
        {
            if (sum > target)
                return;
            else if (sum == target)
            {
                result.Add(subSet);
                return;
            }


            for (int i = start; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                    break;
                
                if (i != 0 && candidates[i] == candidates[i - 1])
                    continue;
                
                subSet.Add(candidates[i]);
                Helper(candidates, target, sum + candidates[i], i, subSet.ToList(), result);
                subSet.RemoveAt(subSet.Count - 1);
            }
        }


        /// <summary>
        /// 九章寫法
        /// DFS
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum1(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (candidates == null || candidates.Length == 0)
                return result;

            int[] nums = RemoveDuplicates(candidates);

            Array.Sort(nums);

            DFS(nums, 0, new List<int>(), target, result);

            return result;
        }

        /// <summary>
        /// 把重負的數字去掉
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        private int[] RemoveDuplicates(int[] candidates)
        {
            int index = 0;

            for (int i = 1; i < candidates.Length; i++)
            {
                if (candidates[i] != candidates[index])
                    candidates[++index] = candidates[i];
            }

            int[] nums = new int[index + 1];
            for (int i = 0; i < index + 1; i++)
                nums[i] = candidates[i];

            return nums;
        }

        private void DFS(int[] num, int startIndex, List<int> subSet, int remainTarget, List<IList<int>> result)
        {
            if (remainTarget == 0)
            {
                result.Add(new List<int>(subSet));
                return;
            }

            for (int i = startIndex; i < num.Length; i++)
            {
                if (remainTarget < num[i])
                    break;

                subSet.Add(num[i]);
                DFS(num, i, subSet, remainTarget - num[i], result);
                subSet.RemoveAt(subSet.Count - 1);
            }
        }
    }
}
