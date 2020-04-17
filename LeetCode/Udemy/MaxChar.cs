using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class MaxChar
    {
        public MaxChar()
        {
           // var result = ob.maxChar("abcccccccd");
        }

        /// <summary>
        /// 學來的修改版
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string maxChar(string str)
        {
            Dictionary<char, int> charMap = new Dictionary<char, int>();
            int max = 0;
            char maxChar = new char();
            foreach (var item in str)
                charMap[item] = !charMap.ContainsKey(item) ? 1 : charMap[item] + 1;
            foreach (var item in charMap)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    maxChar = item.Key;
                }
            }

            return maxChar.ToString();
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string maxChar2(string str)
        {
            Dictionary<char, int> dc = new Dictionary<char, int>();

            foreach (var item in str)
            {
                if (dc.ContainsKey(item))
                    dc[item] += 1;
                else
                    dc.Add(item, 1);
            }
            int maxCount = 0;
            char cha = new char();
            foreach (var item in dc)
            {
                if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                    cha = item.Key;
                }
            }
            return cha.ToString();
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string maxChar1(string str)
        {
            var tmp = str.Select(o => o).GroupBy(o => o);
            int maxCount = 0;
            char cha = new char();
            foreach (var item in tmp)
            {
                if (item.Count() > maxCount)
                {
                    maxCount = item.Count();
                    cha = item.Key;
                }
            }
            return cha.ToString();
        }
    }
}
