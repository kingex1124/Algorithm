using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Vowels
    {
        public Vowels()
        {

        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int vowels1(string str)
        {
            int count = 0;
            char[] checker = new char[] { 'a', 'e', 'i', 'o', 'u' };
            foreach (var cha in str.ToLower())
                if (checker.Contains(cha))
                    count++;
            return count;

        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int vowels(string str)
        {
            string strTmp = str.ToLower();
            int result = 0;
            foreach (var ch in strTmp)
            {
                switch (ch)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        result += 1;
                        break;
                }
            }
            return result;
        }
    }
}
