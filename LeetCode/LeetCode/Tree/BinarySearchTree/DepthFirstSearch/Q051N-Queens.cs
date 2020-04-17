using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.DepthFirstSearch
{
    public class Q051N_Queens
    {
        public Q051N_Queens()
        {
            //var result = ob.SolveNQueens(4);
        }

        /// <summary>
        /// 學來的 跟花花得差不多
        /// Good
        /// </summary>
        public class sol3
        {
            public IList<IList<string>> SolveNQueens(int n)
            {
                List<IList<string>> result = new List<IList<string>>();
                char[][] board = new char[n][];
                for (int i = 0; i < n; i++)
                    board[i] = new char[n];

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        board[i][j] = '.';

                bool[] col = new bool[n];
                bool[] diag1 = new bool[2 * n - 1];
                bool[] diag2 = new bool[2 * n - 1];

                DFS(board, 0, n, result, col, diag1, diag2);
                return result;
            }

            private void DFS(char[][] board, int y, int n, List<IList<string>> result, bool[] col, bool[] diag1, bool[] diag2)
            {
                if (y == n)
                {
                    List<string> toAdd = new List<string>();
                    for (int i = 0; i < n; i++)
                        toAdd.Add(new string(board[i]));
                    result.Add(toAdd);
                    return;
                }

                for (int x = 0; x < n; x++)
                {
                    if (col[x] || diag1[x - y + n - 1] || diag2[x + y])
                        continue;

                    col[x] = true;
                    diag1[x - y + n - 1] = true;
                    diag2[x + y] = true;

                    board[y][x] = 'Q';
                    DFS(board, y + 1, n, result, col, diag1, diag2);
                    board[y][x] = '.';

                    col[x] = false;
                    diag1[x - y + n - 1] = false;
                    diag2[x + y] = false;
                }
            }
        }

        /// <summary>
        /// 參考花花的解法再改良的
        /// </summary>
        public class sol2
        {
            bool[] cols;
            bool[] diag1;
            bool[] diag2;
            public IList<IList<string>> SolveNQueens(int n)
            {
                List<IList<string>> result = new List<IList<string>>();
                if (n == 0)
                    return result;

                cols = new bool[n];
                diag1 = new bool[2 * n - 1];
                diag2 = new bool[2 * n - 1];

                string org = string.Empty;
                for (int i = 0; i < n; i++)
                    org += ".";

                NQueens(n, 0, org, new List<string>(), result);

                return result;
            }

            public bool Available(int x, int y, int n)
            {
                return !cols[x] && !diag1[x + y] && !diag2[x - y + n - 1];
            }

            public void UpdateBoard(int x, int y, int n, bool isPut, StringBuilder board)
            {
                cols[x] = isPut;
                diag1[x + y] = isPut;
                diag2[x - y + n - 1] = isPut;

                board[x] = isPut ? 'Q' : '.';
            }

            private void NQueens(int n, int y, string org, List<string> subSet, List<IList<string>> result)
            {
                if (y == n)
                {
                    result.Add(new List<string>(subSet));
                    subSet = new List<string>();
                    return;
                }

                for (int x = 0; x < n; x++)
                {
                    if (!Available(x, y, n))
                        continue;
                    StringBuilder board = new StringBuilder(org);

                    UpdateBoard(x, y, n, true, board);
                    subSet.Add(board.ToString());
                    NQueens(n, y + 1, org, subSet, result);
                    UpdateBoard(x, y, n, false, new StringBuilder(subSet.Last()));
                    subSet.RemoveAt(subSet.Count - 1);
                }
            }
        }

        /// <summary>
        /// 參考花花的解法
        /// good
        /// </summary>
        public class sol1
        {

            List<List<string>> board = new List<List<string>>();
            bool[] cols;
            bool[] diag1;
            bool[] diag2;
            List<IList<string>> sols = new List<IList<string>>();

            public IList<IList<string>> SolveNQueens(int n)
            {
                if (n == 0)
                    return sols;

                for (int i = 0; i < n; i++)
                {
                    List<string> tmp = new List<string>();

                    for (int j = 0; j < n; j++)
                        tmp.Add(".");
                    board.Add(tmp);
                }

                cols = new bool[n];
                diag1 = new bool[2 * n - 1];
                diag2 = new bool[2 * n - 1];

                NQueens(n, 0);

                return sols;
            }

            public bool Available(int x, int y, int n)
            {
                return !cols[x] && !diag1[x + y] && !diag2[x - y + n - 1];
            }

            public void UpdateBoard(int x, int y, int n, bool isPut)
            {
                cols[x] = isPut;
                diag1[x + y] = isPut;
                diag2[x - y + n - 1] = isPut;
                board[y][x] = isPut ? "Q" : ".";
            }

            private void NQueens(int n, int y)
            {
                if (y == n)
                {
                    List<string> tmp = new List<string>();
                    StringBuilder sb;
                    foreach (var item in board)
                    {
                        sb = new StringBuilder();
                        foreach (var st in item)
                            sb.Append(st);

                        tmp.Add(sb.ToString());
                    }

                    sols.Add(new List<string>(tmp));
                    return;
                }

                for (int x = 0; x < n; x++)
                {
                    if (!Available(x, y, n))
                        continue;

                    UpdateBoard(x, y, n, true);
                    NQueens(n, y + 1);
                    UpdateBoard(x, y, n, false);
                }
            }
        }
    }
}
