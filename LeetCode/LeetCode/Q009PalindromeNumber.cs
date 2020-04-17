using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q009PalindromeNumber
    {
        public Q009PalindromeNumber()
        {
            //var result = ob.IsPalindrome(-121);
            //var result2 = ob.IsPalindrome2(121);
        }

        public bool IsPalindrome(int x)
        {
            //負的濾掉 1XXXXX0 不可能對稱 所以濾掉
            if (x < 0 || (x % 10 == 0 && x != 0))
                return false;

            bool result = false;

            string str = x.ToString();

            if (str.Length == 1)
                return true;

            int d = 0;

            while (str[d] == str[str.Length - d - 1])
            {
                if (d == str.Length - d - 1)
                {
                    result = true;
                    break;
                }

                if ((str.Length - d - 1) - d == 1)
                {
                    result = true;
                    break;
                }
                d++;
            }

            return result;
        }

        /// <summary>
        /// 參考別人的
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome2(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
                return false;

            int temp = 0;

            //只看一半
            while (x > temp)
            {
                temp = temp * 10 + x % 10;
                x = x / 10;
            }

            //121 奇數長度的時候 temp除以10
            return x == temp || x == temp / 10;
        }
    }
}
