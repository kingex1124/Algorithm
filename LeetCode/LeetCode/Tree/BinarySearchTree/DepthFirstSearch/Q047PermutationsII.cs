using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.DepthFirstSearch
{
    public class Q047PermutationsII
    {
        public Q047PermutationsII()
        {

        }

        /// <summary>
        /// 學來的
        /// DFS解法
        /// O(n^3)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return result;

            Array.Sort(nums);

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
                    //第一個部分為避免重複取值
                    //後面為 當有相同值時(前一個值) 且被取過就繼續往下走 沒被取過就跳過
                    // 112 初期走到第二個1時 狀態是 F F F 此時會變成 continue(直接跳過)
                    if (visited[i] || i > 0 && nums[i] == nums[i - 1] && !visited[i - 1])
                        continue;
                    subSet.Add(nums[i]);
                    visited[i] = true;
                    DFS(nums, visited, subSet, result);
                    subSet.RemoveAt(subSet.Count - 1);
                    visited[i] = false;
                }
            }
        }
    }
}
