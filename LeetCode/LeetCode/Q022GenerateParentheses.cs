using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q022GenerateParentheses
    {
        public Q022GenerateParentheses()
        {
           // var result = ob.GenerateParenthesis(3);
        }

        #region 自己寫的
        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            //用這個會把重複的資料濾掉，這樣記憶體比用List在做Distinct少一半
            HashSet<string> reData = new HashSet<string>();
            //List<string> result = new List<string>();
            GenerateData(1, n, "()", reData);
            return reData.ToList();//result.Distinct().ToList();
        }

        private void GenerateData(int level, int n, string re, HashSet<string> result)
        {
            if (level == n)
            {
                result.Add(re);
                return;
            }
            for (int j = 1; j <= re.Length; j++)
            {
                string tmp = re;
                tmp = tmp.Insert(j, "()");
                GenerateData(level + 1, n, tmp, result);
            }
        }
        #endregion

        /// <summary>
        /// 參考網路上的
        /// 先排( 在排) ( 數量用完就Return回上一層
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis1(int n)
        {
            List<string> result = new List<string>();
            string re = "";
            helper(n, n, re, result);
            return result;
        }

        private void helper(int left, int right, string re, List<string> result)
        {
            if (left < 0 || right < 0 || left > right)
                return;
            if (left == 0 && right == 0)
            {
                result.Add(re);
                return;
            }

            helper(left - 1, right, re + "(", result);

            helper(left, right - 1, re + ")", result);
        }

    }
}
