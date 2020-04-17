using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q412FizzBuzz
    {
        public Q412FizzBuzz()
        {

        }

        /// <summary>
        /// 基本款
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> FizzBuzz1(int n)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    result.Add("FizzBuzz");
                else if (i % 3 == 0)
                    result.Add("Fizz");
                else if (i % 5 == 0)
                    result.Add("Buzz");
                else
                    result.Add(i + "");
            }
            return result;
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> FizzBuzz(int n)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                string tmp = string.Empty;
                if (i % 3 == 0)
                    tmp = "Fizz";
                if (i % 5 == 0)
                    tmp = tmp + "Buzz";
                result.Add(string.IsNullOrWhiteSpace(tmp) ? i + "" : tmp);
            }
            return result;
        }
    }
}
