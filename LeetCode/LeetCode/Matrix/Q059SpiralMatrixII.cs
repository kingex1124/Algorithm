using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Matrix
{
    public class Q059SpiralMatrixII
    {
        public Q059SpiralMatrixII()
        {
            //var result = ob.GenerateMatrix(3);
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GenerateMatrix(int n)
        {
            int[][] results = new int[n][];

            for (int i = 0; i < n; i++)
                results[i] = new int[n];

            int counter = 1;
            int startColumn = 0;
            int endColumn = n - 1;
            int startRow = 0;
            int endRow = n - 1;

            while (startColumn <= endColumn && startRow <= endRow)
            {
                //top row
                for (int i = startColumn; i <= endColumn; i++)
                {
                    results[startRow][i] = counter;
                    counter++;
                }

                startRow++;

                //right column
                for (int i = startRow; i <= endRow; i++)
                {
                    results[i][endColumn] = counter;
                    counter++;
                }

                endColumn--;

                //buttom row
                for (int i = endColumn; i >= startColumn; i--)
                {
                    results[endRow][i] = counter;
                    counter++;
                }

                endRow--;

                //left column 
                for (int i = endRow; i >= startRow; i--)
                {
                    results[i][startColumn] = counter;
                    counter++;
                }
                startColumn++;
            }
            return results;
        }
    }
}
