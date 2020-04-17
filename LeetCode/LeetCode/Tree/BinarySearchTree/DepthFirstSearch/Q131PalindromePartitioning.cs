using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q131PalindromePartitioning
    {
        public Q131PalindromePartitioning()
        {
            //     var re = ob.Partition("aab");
        }

        /// <summary>
        /// 九章
        /// GOOD
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> result = new List<IList<string>>();
            if (s == null || s.Length == 0)
                return result;
            helperSubString(s, 0, new List<string>(), result);
            return result;
        }

        private void helperSubString(string str, int offset, List<string> subSet, List<IList<string>> result)
        {
            if (str.Length == offset)
                result.Add(new List<string>(subSet));
            for (int i = offset; i < str.Length; i++)
            {
                if (IsPalindrome(str, offset, i))
                {
                    subSet.Add(str.Substring(offset, i - offset + 1));
                    helperSubString(str, i + 1, subSet, result);
                    subSet.RemoveAt(subSet.Count - 1);
                }
            }
        }

        public bool IsPalindrome(string s, int start, int end)
        {
            if (s.Length == 0)
                return true;

            while (start < end)
            {
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 九章
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> Partition1(string s)
        {
            List<IList<string>> result = new List<IList<string>>();
            if (s == null || s.Length == 0)
                return result;
            helperSubString1(s, new List<string>(), result);
            return result;
        }

        private void helperSubString1(string str, List<string> subSet, List<IList<string>> result)
        {
            if (str.Length == 0)
                result.Add(new List<string>(subSet));
            int len = str.Length;
            for (int i = 1; i <= len; i++)
            {
                string subString = str.Substring(0, i);
                if (IsPalindrome1(subString))
                {
                    subSet.Add(subString);
                    string restSubString = str.Substring(i);
                    helperSubString1(restSubString, subSet, result);
                    subSet.RemoveAt(subSet.Count - 1);
                }
            }
        }

        public bool IsPalindrome1(string s)
        {
            var che = s.ToCharArray();
            if (che.Length == 0)
                return true;
            int start = 0;
            int end = che.Length - 1;

            while (start < end)
            {
                if (che[start] == che[end])
                {
                    start++;
                    end--;
                }
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> partition2(String s)
        {
            List<IList<string>> result = new List<IList<string>>();
            Backtrack(result, new List<string>(), s, 0);
            return result;
        }

        private void Backtrack(List<IList<string>> result, List<string> subSet, string s, int start)
        {
            if (start == s.Length)
                result.Add(new List<string>(subSet));
            else
            {
                for (int i = start; i < s.Length; i++)
                {
                    if(IsPalindrome2(s,start,i))
                    {
                        subSet.Add(s.Substring(start, i - start + 1));
                        Backtrack(result, subSet, s, i + 1);
                        subSet.RemoveAt(subSet.Count - 1);
                    }
                }
            }
        }

        private bool IsPalindrome2(string s, int low, int high)
        {
            while (low < high)
                if (s[low++] != s[high--]) return false;
            return true;
        }
    }
}
