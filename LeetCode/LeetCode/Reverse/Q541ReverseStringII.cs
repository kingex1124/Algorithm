using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q541ReverseStringII
    {
        public Q541ReverseStringII()
        {
            //string result = ob.ReverseStr("hyzqyljrnigxvdtneasepfahmtyhlohwxmkqcdfehybknvdmfrfvtbsovjbdhevlfxpdaovjgunjqlimjkfnqcqnajmebeddqsgl", 39);
        }

        #region 網路上查的
        /// <summary>
        /// 每K個反轉，K個不轉，循環
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string ReverseStr(string s, int k)
        {
            int st = 0;
            char[] cha = s.ToCharArray();
            int len = s.Length;

            while (st < len)
            {
                ReverseHelp(cha, st, Math.Min(len - 1, st + k - 1));
                st = Math.Min(len, st + 2 * k);
            }

            return new string(cha);
        }
        public void ReverseHelp(char[] s, int start, int end)
        {
            while (start < end)
            {
                char cha = s[end];
                s[end--] = s[start];
                s[start++] = cha;
            }
        }
        #endregion

        #region 自己想的
        public string ReverseStr1(string s, int k)
        {
            char[] cha = s.ToCharArray();
            int len = s.Length;
            for (int i = 0; i < cha.Length; i += k)
                if (i % (2 * k) == 0)
                    ReverseHelp(cha, i, k > len - (i + 1) ? len - 1 : i + k - 1);


            return new string(cha); //string.Join(cha); //這樣寫比較慢的樣子
            //舊的寫法
            //for (int i = 0; i < len; i += k)
            //{
            //    if (i % (2 * k) == 0)
            //        result += ReverseHelp(s.Substring(i, k > len - (i + 1) ? len - i : k).ToCharArray());
            //    else
            //        result += s.Substring(i, k > len - (i + 1) ? len - i : k);
            //}
        }
        #endregion
    }
}
