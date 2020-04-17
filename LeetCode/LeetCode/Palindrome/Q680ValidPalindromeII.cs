using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q680ValidPalindromeII
    {
        public Q680ValidPalindromeII()
        {
            // var result = ob.ValidPalindrome("aydmda");
        }

        #region 精簡版

        /// <summary>
        /// 精簡版
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPalindrome2(string s)
        {
            int start = 0;
            var cha = s.ToCharArray();
            int len = cha.Length - 1;
            while (start < len)
            {
                if (cha[start] != cha[len])
                    return PalindromeHelp2(s, start + 1, len) || PalindromeHelp2(s, start, len - 1);
                start++;
                len--;
            }
            return true;
        }

        public bool PalindromeHelp2(string s, int start, int end)
        {
            var cha = s.ToCharArray();
            while (start < end)
            {
                if (cha[start++] != cha[end--])
                    return false;
            }
            return true;
        }

        #endregion

        #region 改良版1

        /// <summary>
        /// 改良版1
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPalindrome1(string s)
        {
            int start = 0;
            var cha = s.ToCharArray();
            int len = cha.Length - 1;
            while (start < len)
            {
                if (cha[start] == cha[len])
                {
                    start++;
                    len--;
                }
                else
                    return PalindromeHelp1(s, start + 1, len) || PalindromeHelp1(s, start, len - 1);
            }
            return true;
        }

        public bool PalindromeHelp1(string s, int start, int end)
        {
            var cha = s.ToCharArray();
            while (start < end)
            {
                if (cha[start] == cha[end])
                {
                    start++;
                    end--;
                }
                else
                    return false;
            }
            return true;
        }

        #endregion

        #region 自己的寫法

        /// <summary>
        /// 自己的寫法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPalindrome(string s)
        {
            int start = 0;
            var cha = s.ToCharArray();
            int len = cha.Length - 1;
            while (start < len)
            {
                if (cha[start] == cha[len])
                {
                    start++;
                    len--;
                }
                else
                {
                    //扣去一個數了，長度都是少1
                    if (PalindromeHelp(s.Substring(start + 1, len - start)))
                        return true;
                    else if (PalindromeHelp(s.Substring(start, len - start)))//扣去一個數了，長度都是少1
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }

        public bool PalindromeHelp(string s)
        {
            int start = 0;
            var cha = s.ToCharArray();
            int len = cha.Length - 1;
            while (start < len)
            {
                if (cha[start] == cha[len])
                {
                    start++;
                    len--;
                }
                else
                    return false;
            }
            return true;
        }

        #endregion

    }
}
