using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q557ReverseWordsinaStringIII
    {
        public Q557ReverseWordsinaStringIII()
        {
            //var resilt = ob.ReverseWords("Let's take LeetCode contest");
        }


        #region 自己寫的
        /// <summary>
        /// 自己寫的
        /// 這個比較好
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            string result = string.Empty;
            var word = s.Split(' ');
            List<string> wordList = new List<string>();
            foreach (var item in word)
            {
                var tmp = item.ToCharArray();
                wordList.Add(ReveredHelp(tmp));
            }
            return string.Join(" ", wordList);
        }

        public string ReveredHelp(char[] word)
        {
            int start = 0;
            int len = word.Length - 1;
            while (start < len)
            {
                var cha = word[len];
                word[len--] = word[start];
                word[start++] = cha;
            }
            return new string(word);
        }

        #endregion

        #region 參考網路上的
        /// <summary>
        /// 參考網路
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords1(string s)
        {
            StringBuilder sb = new StringBuilder();
            string result = string.Empty;
            var word = s.Split(' ');
            List<string> wordList = new List<string>();
            foreach (var item in word)
            {
                var tmp = item.ToCharArray();
                sb.Append(ReveredHelp(tmp)).Append(" ");
                wordList.Add(ReveredHelp(tmp));
            }
            return sb.ToString().TrimEnd();
        }

        public string ReveredHelp1(char[] word)
        {
            int start = 0;
            int len = word.Length - 1;
            while (start < len)
            {
                var cha = word[len];
                word[len--] = word[start];
                word[start++] = cha;
            }
            return new string(word);
        }

        #endregion
    }
}
