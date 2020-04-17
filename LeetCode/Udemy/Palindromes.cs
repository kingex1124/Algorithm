using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Palindromes
    {
        public Palindromes()
        {
            //var res = ob.palindrome4("abba");
        }

        public bool palindrome4(string s)
        {
            return s.ToCharArray().All(cha => cha == s[s.Length - s.IndexOf(cha) - 1]);
        }

        public bool palindrome3(string s)
        { 
            return s == new string(s.ToCharArray().Reverse().ToArray());
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool palindrome2(string s)
        {
            int st = 0;
            var charray = s.ToCharArray();
            int len = s.Length - 1;           
            while (st < len)
            {
                char cha = charray[st];
                charray[st++] = charray[len];
                charray[len--] = cha;
            }
            return s == new string(charray);
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <returns></returns>
        public bool palindrome1(string s)
        {
            string reversed = string.Empty;
            foreach (var cha in s)
                reversed = cha + reversed;
            return s == reversed;
        }
    }
}
