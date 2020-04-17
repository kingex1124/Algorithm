using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Steps
    {
        public Steps()
        {
            //ob.steps(5);
        }

        /// <summary>
        /// 學來的遞迴解法
        /// </summary>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="stair"></param>
        public void steps(int n, int row = 0, string stair = "")
        {
            if (n == row)
                return;
            if (n == stair.Length)
            {
                Console.WriteLine(stair);
                steps(n, row + 1);
                return;
            }

            string add = stair.Length <= row ? "#" : " ";
            steps(n, row, stair + add);

            //if (stair.Length <= row)
            //    stair += "#";
            //else
            //    stair += " ";

            //steps(n, row, stair);
        }

        /// <summary>
        /// 學來的 index 解法
        /// O(n^2)
        /// </summary>
        /// <param name="n"></param>
        public void steps(int n)
        {
            for (int row = 0; row < n; row++)
            {
                string result = string.Empty;
                for (int column = 0; column < n; column++)
                {
                    if (column <= row)
                        result += "#";
                    else
                        result += " ";
                }
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// 自己寫的
        /// O(n^2)
        /// </summary>
        /// <param name="n"></param>
        public void steps1(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                string shar = string.Empty;
                shar = printshar("#", i);
                shar += printshar(" ", n - i);
                Console.WriteLine(shar);
            }
        }

        public string printshar(string note, int n)
        {
            string result = string.Empty;
            for (int i = 1; i <= n; i++)
                result += note;

            return result;
        }
    }
}
