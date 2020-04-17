using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Capitalize
    {
        public Capitalize()
        {
            // var result = ob.capitalize("a short sentence");
        }

        /// <summary>
        /// 學來的
        /// O(n)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string capitalize(string str)
        {
            string result = (str[0] + "").ToUpper();
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str[i - 1] == ' ')
                    result += (str[i] + "").ToUpper();
                else
                    result += str[i];
            }

            return result;
        }

        /// <summary>
        /// 自己寫的
        /// O(n)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string capitalize1(string str)
        {
            string[] sp = str.Split(' ');

            for (int i = 0; i < sp.Length; i++)
                sp[i] = (sp[i][0] + "").ToUpper() + sp[i].Substring(1); //sp[i].Replace(sp[i][0], (char)(sp[i][0] - 32));

            return string.Join(" ", sp);
        }
    }
}
