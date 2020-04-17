using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q852PeakIndexinaMountainArray
    {
        public Q852PeakIndexinaMountainArray()
        {
            //var result = ob.PeakIndexInMountainArray(new int[] { 3, 4, 5, 1 });
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray(int[] A)
        {
            if (A == null || A.Length == 0)
                return -1;
            int start = 0;
            int end = A.Length - 1;

            while (start < end)
            {
                int mid = start + (end - start) / 2;
                //局部順逆判斷
                if (A[mid] < A[mid + 1])
                    start = mid + 1;
                else
                    end = mid;
            }

            return end;
        }
    }
}
