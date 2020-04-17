
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q278FirstBadVersion
    {
        public Q278FirstBadVersion()
        {
            //var result = ob.FirstBadVersion(2126753390);
            //var result = ob.FirstBadVersion1(999);
        }

        /// <summary>
        /// 此作法不會切掉mid位置 所以最後會直接到start位置(收斂) 
        /// start +1 <end 是為了剛好切到開始位置離開迴圈
        /// O(logn)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int start = 1;
            int end = n;

            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;

                if (IsBadVersion(mid))
                    end = mid;
                else
                    start = mid;
            }
            if (IsBadVersion(start))
                return start;
            return end;
        }

        /// <summary>
        /// 此作法，如果剛好切到mid是true，之後的會一直從START逼近，最後會變成
        /// 500 <= 499 然後驗start 符合的話就是答案
        /// O(logn)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion1(int n)
        {
            int start = 1;
            int end = n;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (IsBadVersion(mid))
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            if (IsBadVersion(start))
                return start;
            return end;
        }

        public bool IsBadVersion(int n)
        {
            //return n >= 1702766719;
            return n >= 500;
        }
    }
}
