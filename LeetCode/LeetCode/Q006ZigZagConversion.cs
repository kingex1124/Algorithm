using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q006ZigZagConversion
    {
        public Q006ZigZagConversion()
        {
            //var result = ob.Convert("PAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRINGPAYPALISHIRING", 3)
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            string result = "";
            int w = 2 * numRows - 2;
            if (s.Length == 1 || w == 0)
                return s;
            //StringBuilder
            for (int i = 0; i < numRows; i++)
            {
                for (int j = i; j < s.Length; j += w)
                {
                    //直列
                    result += s[j];
                    //斜線
                    if (i != 0 && i != numRows - 1 && (j - i) + (w - i) < s.Length)
                        //扣掉i的起始距離(位置)
                        result += s[(j - i) + (w - i)];
                }
            }
            return result;
        }

        /// <summary>
        /// 網路上參考的
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert2(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0 || numRows <= 1)
                return s;
            StringBuilder[] array = new StringBuilder[numRows];

            for (int i = 0; i < array.Length; i++)
                array[i] = new StringBuilder();
            int dir = 1;
            int index = 0;
            foreach (var c in s.ToCharArray())
            {
                array[index].Append(c);
                index += dir;
                if (index == 0 || index == numRows - 1)
                    dir = -dir;
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
                result.Append(array[i]);
            return result.ToString();
        }

        /// <summary>
        /// 改良成讓人好懂得版本
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert3(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0 || numRows <= 1)
                return s;
            string[] array = new string[numRows];

            int dir = 1;
            int index = 0;
            foreach (var c in s.ToCharArray())
            {
                array[index] += c;
                index += dir;
                if (index == 0 || index == numRows - 1)
                    dir = -dir;
            }

            string result = "";
            for (int i = 0; i < array.Length; i++)
                result += array[i];
            return result;
        }
    }
}
