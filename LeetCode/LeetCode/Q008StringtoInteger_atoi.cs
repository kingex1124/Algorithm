using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q008StringtoInteger_atoi
    {
        public Q008StringtoInteger_atoi()
        {
            //var result = ob.MyAtoi("words and 987");
        }

        /// <summary>
        /// 傳入字串，取最開頭的數字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int MyAtoi(string str)
        {
            int result = 0;
            str = str.Trim();
            str = str.Split(' ')[0];
            if (string.IsNullOrEmpty(str))
                return 0;
            string first = "";
            if (str[0] == 45 || str[0] == 43)
            {
                first = str[0].ToString();
                str = str.Substring(1, str.Length - 1);
            }
            char[] arr = str.ToCharArray();

            string resultTemp = "";
            double temp = 0;

            foreach (var c in arr)
            {
                if (c == 46 || (c >= 48 && c <= 57))
                    resultTemp += c.ToString();
                else
                    break;
            }

            if (String.IsNullOrEmpty(resultTemp))
                return 0;
            resultTemp = first + resultTemp;
            temp = Convert.ToDouble(resultTemp);

            if (temp <= int.MinValue)
                result = int.MinValue;
            else if (temp >= int.MaxValue)
                result = int.MaxValue;
            else
                result = (int)temp;

            return result;
        }
    }
}
