using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q014LongestCommonPrefix
    {
        public Q014LongestCommonPrefix()
        {
            // var result = ob.LongestCommonPrefix(new string[] { "flower", "flow", "flight" });
            // var result = ob.LongestCommonPrefix(new string[] {"c", "c"});
        }

        /// <summary>
        /// 第一種解法
        /// 用SubString方式刪減字元
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            if (strs[0] == "")
                return "";
            string result = string.Empty;
            result = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i] == "")
                    return "";
                for (int j = 0; j < strs[i].Length; j++)
                {
                    if (result.Length < j + 1)
                    {
                        result = result.Substring(0, j);
                        break;
                    }
                    else if (result[j] != strs[i][j])
                    {
                        result = result.Substring(0, j);
                        break;
                    }
                    else if (strs[i].Length == j + 1 && result[j] != strs[i][j])
                    {
                        result = result.Substring(0, j - 1);
                        break;
                    }
                    else if (strs[i].Length == j + 1 && result[j] == strs[i][j])
                    {
                        result = result.Substring(0, j + 1);
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 第二種解法 GOOD
        /// 用StringBuilder方式把相同字元加進來
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix1(string[] strs)
        {
            if (strs.Length == 0 || strs[0] == "")
                return "";
            string result = string.Empty;
            result = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                if (strs[i] == "" || result == "")
                    return "";
                for (int j = 0; j < strs[i].Length; j++)
                {
                    if (result[0] != strs[i][0] || result.Length < j + 1)
                        break;
                    if (result[j] == strs[i][j])
                        sb.Append(strs[i][j]);
                }
                result = sb.ToString();
            }
            return result;
        }

        /// <summary>
        /// 第三種解法(參考網路上)
        /// 用扣除尾端的方式求解
        /// 比對後，沒有相等的值，就扣除一個最尾端的字元
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix2(string[] strs)
        {
            if (strs.Length == 0 || strs[0] == "")
                return "";
            string result = string.Empty;
            StringBuilder sb = new StringBuilder(strs[0]);
            //取最後一個 
            int i = sb.Length - 1;
            //從第一個開始
            int j = 1;
            while (i >= 0 && j < strs.Length)
            {
                //比對後，沒有相等的值，就扣除一個最尾端的字元
                if (strs[j].IndexOf(sb.ToString()) != 0)
                {
                    //從最後一個開始扣除
                    //刪調有差異的部分
                    sb.Remove(i, 1);
                    i--;
                }
                else
                    j++;
            }
            result = sb.ToString();
            return result;
        }

    }
}
