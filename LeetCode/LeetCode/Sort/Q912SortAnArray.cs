using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Sort
{
    public class Q912SortAnArray
    {
        public Q912SortAnArray()
        {

        }

        /// <summary>
        /// O(n^2)
        /// Bubble Sort
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> SortArray(int[] nums)
        {
            //  Optimized with noSwaps
            bool swap;
            for (int i = nums.Length; i > 0; i--)
            {
                swap = true;
                for (int j = 0; j < i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        var tmp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmp;
                        swap = false;
                    }
                }
                if (swap) break;
            }
            return nums;
        }

        /// <summary>
        /// O(n^2)
        /// Selection Sort
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> SortArray1(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int lowest = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[lowest])
                        lowest = j;
                }
                if (i != lowest)
                {
                    var tmp = nums[i];
                    nums[i] = nums[lowest];
                    nums[lowest] = tmp;
                }
            }
            return nums;
        }

        /// <summary>
        /// O(n^2)
        /// Insertion Sort
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> SortArray2(int[] nums)
        {
            int j = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                var currentval = nums[i];
                for (j = i - 1; j >= 0 && nums[j] > currentval; j--)
                    nums[j + 1] = nums[j];
                nums[j + 1] = currentval;
            }
            return nums;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> SortArray3(int[] nums)
        {
            Array.Sort(nums);
            return nums.ToList();
        }

        public IList<int> merge(int[] arr1,int[] arr2)
        {
            List<int> result = new List<int>();
            int i = 0;
            int j = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr2[j] > arr1[i])
                {
                    result.Add(arr1[i]);
                    i++;
                }
                else
                {
                    result.Add(arr2[j]);
                    j++; 
                }
            }
            while (i<arr1.Length)
            {
                result.Add(arr1[i]);
                i++;
            }
            while (j<arr2.Length)
            {
                result.Add(arr2[j]);
                j++;
            }
            return result;
        }

        public void mergeSort(int [] arr)
        {

        }
    }
}
