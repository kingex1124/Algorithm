using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Matrix
{
    public class Q054SpiralMatrix
    {
        public Q054SpiralMatrix()
        {
            //int[][] ma = new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 } };
            //int[][] ma = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };

            //var result = ob.SpiralOrder(ma);

        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> results = new List<int>();

            if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
                return results;

            int rowLen = matrix.Length;
            int columnLen = matrix[0].Length;
            int startRow = 0;
            int endRow = rowLen - 1;
            int startColumn = 0;
            int endColumn = columnLen - 1;

            while (startRow <= endRow && startColumn <= endColumn)
            {
                for (int i = startColumn; i <= endColumn; i++)
                    results.Add(matrix[startRow][i]);
                startRow++;

                if (results.Count == rowLen * columnLen)
                    return results;

                for (int i = startRow; i <= endRow; i++)
                    results.Add(matrix[i][endColumn]);
                endColumn--;

                if (results.Count == rowLen * columnLen)
                    return results;

                for (int i = endColumn; i >= startColumn; i--)
                    results.Add(matrix[endRow][i]);
                endRow--;

                for (int i = endRow; i >= startRow; i--)
                    results.Add(matrix[i][startColumn]);
                startColumn++;
            }

            return results;
        }

    }
}
