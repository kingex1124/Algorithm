using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q012IntegertoRoman
    {
        public Q012IntegertoRoman()
        {
            //   var result = ob.IntToRoman(8);
        }

        //     Symbol      Value
        //       I           1
        //       V           5
        //       X           10
        //       L           50
        //       C           100
        //       D           500
        //       M           1000
        //Input is guaranteed to be within the range from 1 to 3999.
        /// <summary>
        /// 輸入數字，回傳羅馬字母，數字限定1~3999之間
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman(int num)
        {
            string result = string.Empty;
            if (num > 0 && num < 4000)
            {
                result += RomanChars(num / 1000, "M", "", "");
                result += RomanChars(num % 1000 / 100, "C", "D", "M");
                result += RomanChars(num % 100 / 10, "X", "L", "C");
                result += RomanChars(num % 10, "I", "V", "X");
            }
            else
                result = null;
            return result;
        }

        public string RomanChars(int num, string one, string five, string ten)
        {
            string result = string.Empty;

            switch (num)
            {
                case 0:
                    result = string.Empty;
                    break;
                case 4:
                    result += one + five;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    result += five;
                    num -= 5;
                    goto case 1;
                case 1:
                case 2:
                case 3:
                    while (num > 0)
                    {
                        result += one;
                        num--;
                    }
                    break;
                case 9:
                    result += one + ten;
                    break;
            }

            return result;
        }
    }
}
