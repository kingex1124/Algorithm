using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.DepthFirstSearch
{
    public class Q040CombinationSumII
    {
        public Q040CombinationSumII()
        {

        }

        /// <summary>
        /// 自己寫+參考別人的
        /// DFS
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
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
            else
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    if (i > start && candidates[i] == candidates[i - 1]) continue;
                    subSet.Add(candidates[i]);
                    Helper(candidates, target, sum + candidates[i], i + 1, subSet.ToList(), result);
                    subSet.RemoveAt(subSet.Count - 1);
                }
            }
        }
    }
}
