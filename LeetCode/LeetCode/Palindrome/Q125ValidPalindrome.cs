using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q125ValidPalindrome
    {
        public Q125ValidPalindrome()
        {
            //var t = ob.IsPalindrome(@"A man, a plan, a canal: Panama");
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome2(string s)
        {
            char[] c = s.ToCharArray();
            for (int i = 0, j = c.Length - 1; i < j;)
                if (!char.IsLetterOrDigit(c[i]))
                    i++;
                else if (!char.IsLetterOrDigit(c[j]))
                    j--;
                else if (char.ToLower(c[i++]) != char.ToLower(c[j--]))
                    return false;

            return true;
        }

        /// <summary>
        /// 自己寫的改良版
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome1(string s)
        {
            List<int> chalist = new List<int>();
            CheckEnglish1(s.ToCharArray(), chalist);

            if (chalist.Count == 0)
                return true;
            int start = 0;
            int len = chalist.Count - 1;

            while (start < len)
                if (chalist[start++] != chalist[len--])
                    return false;
            return true;
        }

        public void CheckEnglish1(char[] cha, List<int> res)
        {
            foreach (var c in cha)
            {
                if ((c >= 97 && c <= 122) || (c >= 48 && c <= 57))
                {
                    res.Add(c);
                    continue;
                }
                if (c >= 65 && c <= 90)
                    res.Add(c + 32);
            }
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            StringBuilder sb = new StringBuilder();
            CheckEnglish(s.ToUpper().ToCharArray(), ref sb);
            char[] arr = sb.ToString().ToCharArray();
            if (arr.Length == 0)
                return true;

            int start = 0;
            int len = arr.Length - 1;

            while (start < len)
            {
                if (arr[start] == arr[len])
                {
                    start++;
                    len--;
                }
                else
                    return false;
            }
            return true;
        }
        public void CheckEnglish(char[] cha, ref StringBuilder sb)
        {
            foreach (var c in cha)
            {
                if ((c >= 65 && c <= 90) || (c >= 48 && c <= 57))
                    sb.Append(c);
            }
        }
    }
}
