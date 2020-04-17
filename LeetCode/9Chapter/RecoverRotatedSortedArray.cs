using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._9Chapter
{
    public class RecoverRotatedSortedArray
    {
        public RecoverRotatedSortedArray()
        {

        }

        public void reverse(List<int> nums, int start, int end)
        {
            for (int i = start, j = end; i < j; i++, j--)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }

        /// <summary>
        /// 九章學的
        /// 相當於陣列向左平移K次
        /// </summary>
        /// <param name="nums"></param>
        public void recoverRotatedSortedArray(List<int> nums)
        {
            for (int index = 0; index < nums.Count - 1; index++)
            {
                //找到第一個比後面的數大的數，以[4,5,1,2,3]為例，找到5，翻轉[4,5]得到[5,4]，翻轉[1,2 ,3]得到[3,2,1] 
                //最後翻轉[5,4,3,2,1]得到[1,2,3,4,5]
                if (nums[index] > nums[index + 1])
                {
                    reverse(nums, 0, index);
                    reverse(nums, index + 1, nums.Count - 1);
                    reverse(nums, 0, nums.Count - 1);
                    return;
                }
            }
        }
    }
}
