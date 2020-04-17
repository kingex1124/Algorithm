using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q013RomantoInteger
    {
        public Q013RomantoInteger()
        {

        }

        //     Symbol      Value
        //       I           1
        //       V           5
        //       X           10
        //       L           50
        //       C           100
        //       D           500
        //       M           1000
        /// <summary>
        /// 將羅馬數字轉為阿拉伯數字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            int result = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                int val = GetValue(s[i]);
                //前半為非第一筆時的條件
                if (i < s.Length - 1 && GetValue(s[i + 1]) > val)
                    result -= val;
                else
                    result += val;
            }
            return result;
        }

        public int GetValue(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
