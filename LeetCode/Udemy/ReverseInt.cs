using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class ReverseInt
    {
        public ReverseInt()
        {
            // var result = ob.reveserInt(5);
        }

        public int reveserInt(int n)
        {
            int sign = Math.Sign(n);
            int result = 0;

            while (n != 0)
            {
                result = result * 10 + n % 10;
                n = n / 10;
            }
            return result;
        }
    }
}
