using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.BinarySearch
{
    public class Q240Searcha2DMatrixII
    {
        public Q240Searcha2DMatrixII()
        {
            //var result =
            //    ob.SearchMatrix(new int[5, 5] {
            //        { 1, 4, 7, 11, 15 } ,
            //    {2,5,8,12,19 },
            //    {3,6,9,16,22 },
            //    { 10,13,14,17,24},
            //    { 18,21,23,26,30} },
            //    20);

            //var result =
            //  ob.SearchMatrix(new int[1, 1] {
            //        {-5 } },
            //  -5);
        }

        /// <summary>
        /// 參考九章後調整
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix2(int[,] matrix, int target)
        {
            int row = matrix.GetLength(0) - 1;
            int col = 0;

            while (row >= 0 && col < matrix.GetLength(1))
            {
                if (matrix[row, col] == target)
                    return true;
                if (matrix[row, col] > target)
                    row--;
                else
                    col++;
            }
            return false;
        }


        /// <summary>
        /// 九章解2
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchMatrix1(int[][] matrix, int target)
        {
            int row = matrix.GetLength(0);
            int col = 0;
            int ans = 0;

            while (row >= 0 && col < matrix.GetLength(1))
            {
                if (target == matrix[row][col])
                {
                    ans++;
                    row--;
                    col++;
                }
                if (target < matrix[row][col])
                    row--;
                else
                    col++;
            }

            return ans;
        }

        /// <summary>
        /// 參考九章後改良的1
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix1(int[,] matrix, int target)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return false;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int row = n - 1;
            int col = 0;
            while (row >= 0 && col < m)
            {
                if (matrix[row, col] < target)
                    col++;
                else if (matrix[row, col] > target)
                    row--;
                else
                    return true;

            }
            return false;
        }

        /// <summary>
        /// 參考九章
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int x = n - 1;
            int y = 0;
            int count = 0;
            //matrix[x,y]
            while (x >= 0 && y < m)
            {
                if (matrix[x][y] < target)
                    y++;
                else if (matrix[x][y] < target)
                    x--;
                else
                {
                    count++;
                    x--;
                    y++;
                }
            }
            return 0;
        }

        /// <summary>
        /// 自己寫的
        /// 先找有沒有在範圍內
        /// 然後再範圍內用二分搜尋
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] > target || matrix[i, matrix.GetLength(1) - 1] < target)
                    continue;

                int start = 0;
                int end = matrix.GetLength(1) - 1;

                while (start <= end)
                {
                    int mid = start + (end - start) / 2;
                    if (matrix[i, mid] == target)
                        return true;
                    if (matrix[i, mid] <= target)
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
            }
            return false;
        }
    }
}
