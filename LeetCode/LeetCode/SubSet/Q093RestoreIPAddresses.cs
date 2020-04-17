using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q093RestoreIPAddresses
    {
        public Q093RestoreIPAddresses()
        {
            //   var result = ob.RestoreIpAddresses1("25525511135");
        }

        /// <summary>
        /// 方法一
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> result = new List<string>();
            if (s.Length == 0 || string.IsNullOrWhiteSpace(s))
                return result;
            helper(s, 0, "", result);
            return result;
        }

        public void helper(string s, int numCut, string subSet, List<string> result)
        {
            //切4段
            if (numCut == 4)
            {
                //還有剩就表示錯誤
                if (string.IsNullOrWhiteSpace(s))
                    result.Add(subSet);
                return;
            }
            else if (numCut == 3 && s.Length > 3)//處理最後3碼的時候才可以繼續，超過就不合理
                return;

            //每段最長只有3位數所以取1~3
            for (int i = 1; i < 4; i++)
            {
                //超過長度，跳脫
                if (s.Length < i) break;
                //取1~3碼來驗證
                string subString = s.Substring(0, i);
                int val = int.Parse(subString);
                //IP 0~255 範圍 超過不合規定 || 字串00 數字 0 也不合法
                if (val > 255 || subString.Length != val.ToString().Length)
                    continue;
                //切最後一刀的時候 不給 "."
                helper(s.Substring(i), numCut + 1, subSet + subString + (numCut == 3 ? "" : "."), result);
            }
        }

        /// <summary>
        /// 方法二
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddresses1(string s)
        {
            List<string> result = new List<string>();
            if (s.Length == 0 || string.IsNullOrWhiteSpace(s))
                return result;
            helper1(s, 0, 0, new StringBuilder(), result);
            return result;
        }

        public void helper1(string s, int startIndex, int numCuts, StringBuilder sb, List<string> result)
        {
            int len = s.Length;
            if (numCuts == 4)
            {
                if (startIndex == len)
                    result.Add(sb + "");
                return;
            }
            else if (numCuts == 3 && startIndex < len - 3)//處理最後3碼的時候才可以繼續
                return;

            for (int i = startIndex; i < startIndex + 3 && i < len; i++)
            {
                string subStr = s.Substring(startIndex, i - startIndex + 1);
                int val = Convert.ToInt32(subStr);

                // check to see if this is a valid IP address 
                if (!isValid1(subStr, val)) continue;

                // record current length of StringBuilder 
                int ln = sb.Length;
                // if this is the last cut, then we don't put dot '.'
                if (numCuts == 3) sb.Append(subStr);
                else sb.Append(subStr + ".");

                // go for the next cut 
                helper1(s, i + 1, numCuts + 1, sb, result);

                // backtracking
                sb = new StringBuilder(sb.ToString().Substring(0, ln));
            }
        }

        private bool isValid1(string s, int val)
        {
            // invalid case 1: val != 0 but s starts with 0
            if (s[0] == '0' && val != 0) return false;

            // invalid case 2: val == 0 but s has multiple 0s 
            if (s.Length > 1 && val == 0) return false;

            // invalid case 3: val > 255
            if (val > 255) return false;

            return true;
        }
    }
}
