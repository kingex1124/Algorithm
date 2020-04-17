using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q374GuessNumberHigherorLower
    {
        public Q374GuessNumberHigherorLower()
        {
            //var result = ob.guessNumber(10);
        }

        /// <summary>
        /// 模板
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int guessNumber(int n)
        {
            int start = 0;
            int end = n;

            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;

                if (guess(mid) < 0)
                    end = mid;
                else
                    start = mid;
            }
            if (guess(start) == 0)
                return start;
            return n;
        }

        public int guess(int num)
        {
            int pick = 6;

            if (pick == num)
                return 0;
            else if (pick < num)
                return -1;
            else
                return 1;
        }
    }
}
