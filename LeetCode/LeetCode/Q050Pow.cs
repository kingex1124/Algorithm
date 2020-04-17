using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q050Pow
    {
        public Q050Pow()
        {

        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            if (n == 1) return x;
            int t = n / 2;
            if (n < 0)
            {
                t = -t;
                x = 1 / x;
            }
            double res = MyPow(x, t);
            if (n % 2 == 0) return res * res;
            return res * res * x;
        }
    }
}
