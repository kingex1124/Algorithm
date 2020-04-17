using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q074Searcha2DMatrix
    {
        public Q074Searcha2DMatrix()
        {
            //int[][] pr = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 50 } };
            //int[][] pr = new int[][] { new int[] { 1}, new int[] {3 } };
            //var result = ob.SearchMatrix(pr, 3);
        }

        /// <summary>
        /// 九章
        /// 當成一列來計算
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
                return false;

            int row = matrix.Length;
            int column = matrix[0].Length;

            int start = 0;
            //全部為0~11
            int end = row * column - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                //matrix[row][column]
                int number = matrix[mid / column][mid % column];
                if (number == target)
                    return true;
                else if (target < number)
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            return false;
        }

        /// <summary>
        /// Binary Search Twice
        /// 九章
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix1(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
                return false;

            int row = matrix.Length;
            int colum = matrix[0].Length;

            int start = 0;
            int end = row - 1;

            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;
                if (matrix[mid][0] == target)
                    return true;
                else if (matrix[mid][0] < target)
                    start = mid;
                else
                    end = mid;
            }

            if (matrix[end][0] <= target)
                row = end;
            else if (matrix[start][0] <= target)
                row = start;
            else
                return false;

            start = 0;
            end = colum - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (matrix[row][mid] == target)
                    return true;
                if (matrix[row][mid] <= target)
                    start = mid + 1;
                else
                    end = mid - 1;
            }

            return false;
        }
    }
}
