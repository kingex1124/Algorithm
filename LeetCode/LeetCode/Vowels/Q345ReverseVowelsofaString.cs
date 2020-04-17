using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Vowels
{
    public class Q345ReverseVowelsofaString
    {
        public Q345ReverseVowelsofaString()
        {
            //var result = ob.ReverseVowels("leetcode");
        }

        /// <summary>
        /// 自己寫+參考網路
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseVowels(string s)
        {
            int start = 0;
            int end = s.Length - 1;

            char[] chArr = s.ToCharArray();
            while (start < end)
            {
                while (start < end && !isVowel(chArr[start])) start++;
                while (start < end && !isVowel(chArr[end])) end--;

                char tmpStart = chArr[start];
                chArr[start++] = chArr[end];
                chArr[end--] = tmpStart;
            }
            return new string(chArr);
        }

        public bool isVowel(char ch)
        {
            switch (ch)
            {
                case 'a':
                case 'A':
                case 'e':
                case 'E':
                case 'i':
                case 'I':
                case 'o':
                case 'O':
                case 'u':
                case 'U':
                    return true;
                    break;
            }
            return false;
            //char[] checker = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            //return checker.Contains(ch);
        }
    }
}
