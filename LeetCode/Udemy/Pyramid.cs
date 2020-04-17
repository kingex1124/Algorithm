using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Pyramid
    {
        public Pyramid()
        {
            // ob.pyramid(10,0);
        }

        /// <summary>
        /// 遞迴解法
        /// </summary>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="level"></param>
        public void pyramid(int n, int row = 0, string level = "")
        {
            if (n == row)
                return;
            if (2 * n - 1 == level.Length)
            {
                Console.WriteLine(level);
                pyramid(n, row + 1);
                return;
            }

            decimal tmp = (2 * n - 1) / 2;
            decimal midPoint = Math.Floor(tmp);

            string add = "";
            if (midPoint - row <= level.Length && level.Length <= midPoint + row)
                add = "#";
            else
                add = " ";
            pyramid(n, row, level + add);
        }


        /// <summary>
        /// 學的跌代解法
        /// </summary>
        /// <param name="n"></param>
        public void pyramid(int n)
        {
            decimal tmp = (2 * n - 1) / 2;
            decimal midPoint = Math.Floor(tmp);
            for (int row = 0; row < n; row++)
            {
                string level = string.Empty;
                for (int column = 0; column < 2 * n - 1; column++)
                {
                    if (midPoint - row <= column && column <= midPoint + row)
                        level += "#";
                    else
                        level += " ";
                }
                Console.WriteLine(level);
            }
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="n"></param>
        public void pyramid1(int n)
        {
            for (int row = n - 1; row >= 0; row--)
            {
                string result = string.Empty;
                for (int column = 0; column < n; column++)
                {
                    if (row <= column)
                        result += "#";
                    else
                        result += " ";
                }
                if (row == n - 1)
                    for (int column = 0; column < n - 1; column++)
                        result += " ";

                if (row <= n - 2)
                {
                    for (int column = 0; column < n - 1; column++)
                    {
                        if (column <= (n - 2 - row))
                            result += "#";
                        else
                            result += " ";
                    }
                }
                Console.WriteLine(result);
            }
        }

    }
}
