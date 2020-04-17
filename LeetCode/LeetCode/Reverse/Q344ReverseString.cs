using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q344ReverseString
    {
        public Q344ReverseString()
        {
            //   ob.ReverseString2(new char[] { 'h', 'e', 'l', 'l', 'o' });
        }

        public void ReverseString(char[] s)
        {
            int len = s.Length;
            for (int i = 0; i < len / 2; i++)
            {
                char cha = s[i];
                s[i] = s[len - 1 - i];
                s[len - 1 - i] = cha;
            }
        }

        public void ReverseString2(char[] s)
        {
            int len = s.Length - 1;
            int i = 0;
            while (i < len)
            {
                char cha = s[len];
                s[len--] = s[i];
                s[i++] = cha;
            }
        }
    }
}
