using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q007ReverseInteger
    {
        public Q007ReverseInteger()
        {
            // var result = ob.Reverse(-2147483412);
        }
        public int Reverse(int x)
        {
            long result = 0;
            long s = (long)x;
            while (s != 0)
            {
                if (s >= int.MinValue && s <= int.MaxValue)
                {
                    if (result * 10 > int.MaxValue || result * 10 < int.MinValue)
                    {
                        result = 0;
                        break;
                    }
                    result = result * 10 + s % 10;
                }
                s = s / 10;
            }

            return (int)result;
        }
    }
}
