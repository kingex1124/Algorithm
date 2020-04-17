using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.DepthFirstSearch
{
    public class Q046Permutations
    {
        public Q046Permutations()
        {

        }

        /// <summary>
        /// 九章解法
        /// DFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute1(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return result;

            DFS(nums, new bool[nums.Length], new List<int>(), result);


            return result;
        }

        private void DFS(int[] nums, bool[] visited, List<int> subSet, List<IList<int>> result)
        {
            if (subSet.Count == nums.Length)
            {
                result.Add(new List<int>(subSet));
                return;
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (visited[i])
                        continue;
                    subSet.Add(nums[i]);
                    visited[i] = true;
                    DFS(nums, visited, subSet, result);
                    subSet.RemoveAt(subSet.Count - 1);
                    visited[i] = false;
                }
            }
        }

        /// <summary>
        /// 自己寫+參考別人的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return result;

            Helper(nums, new List<int>(), result);

            return result;
        }

        private void Helper(int[] nums, List<int> subSet, List<IList<int>> result)
        {
            if (subSet.Count == nums.Length)
            {
                result.Add(new List<int>(subSet));
                return;
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (subSet.Contains(nums[i]))
                        continue;
                    subSet.Add(nums[i]);
                    Helper(nums, subSet, result);
                    subSet.RemoveAt(subSet.Count - 1);
                }
            }
        }

    }
}
