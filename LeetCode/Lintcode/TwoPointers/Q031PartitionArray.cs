using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Lintcode.TwoPointers
{
    public class Q031PartitionArray
    {
        public Q031PartitionArray()
        {

        }

        public int PartitionArray(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                while (left <= right && nums[left] < k)
                    left++;
                while (left <= right && nums[right] > k)
                    right--;
                if(left<=right)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;

                    left++;
                    right--;
                }
            }
            return left;
        }
    }
}
