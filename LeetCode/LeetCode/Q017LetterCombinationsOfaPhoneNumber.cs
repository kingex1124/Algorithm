using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q017LetterCombinationsOfaPhoneNumber
    {
        public Q017LetterCombinationsOfaPhoneNumber()
        {
            //var result = ob.LetterCombinations("234");
        }

        /// <summary>
        /// 遞迴用法，樹狀結構從左下開始
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrWhiteSpace(digits)) return new List<string>();
            List<string> result = new List<string>() { };
            string[] dict = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            string re = ""; 
            letterCombinationsDFS(digits, dict, 0, re, result);

            return result;
        }

        /// <summary>
        /// 遞迴方法
        /// </summary>
        /// <param name="digits">原字串</param>
        /// <param name="dict">轉換詞</param>
        /// <param name="level">層級</param>
        /// <param name="re">要存取的字(暫存)</param>
        /// <param name="result">最後回傳的結果</param>
        private void letterCombinationsDFS(string digits, string[] dict, int level, string re, List<string> result)
        {
            if (level == digits.Length)
            {
                result.Add(re);
                return;
            }
            //用減的轉型數字
            //取得字串
            string f = dict[digits[level] - '0'];
            for (int i = 0; i < f.Length; i++)
            {
                string s = re + f[i];
                letterCombinationsDFS(digits, dict, level + 1, s, result);
            }

        }

        /// <summary>
        /// 一層一層的排上去，樹狀結構從上而下，從左而右
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations0(string digits)
        {
            if (string.IsNullOrWhiteSpace(digits)) return new List<string>();
            List<string> result = new List<string>() { "" };
            string[] dict = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            for (int i = 0; i < digits.Length; i++)
            {
                List<string> temp = new List<string>();
                //用減的轉型數字
                string f = dict[digits[i] - '0'];
                for (int j = 0; j < f.Length; j++)
                {
                    foreach (var item in result)
                        temp.Add(item + f[j]);
                }
                result = temp;
            }
            return result;
        }
    }
}
