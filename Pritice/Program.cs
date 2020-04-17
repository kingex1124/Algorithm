using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pritice
{
    class Program
    {
        int count = 0;
        static void Main(string[] args)
        {
            Program pg = new Program();
            var re = pg.RestoreIpAddresses("1111111111");
        }

        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> result = new List<string>();
            if (String.IsNullOrWhiteSpace(s) || s.Length == 0)
                return result;
            helper(s, 0, "", result);
            return result;
        }

        private void helper(string s, int numCut, string subSet, List<string> result)
        {
            if (numCut == 4)
            {
                if (string.IsNullOrWhiteSpace(s))
                    result.Add(subSet);
                return;
            }
            else if (numCut == 3 && s.Length > 3)
                return;

            for (int i = 1; i < 4; i++)
            {
                count++;
                if (s.Length < i)
                    break;

                string subString = s.Substring(0,i);
                int val = int.Parse(subString);

                if (val > 255 || subString.Length != val.ToString().Length)
                    continue;
                helper(s.Substring(i), numCut + 1, subSet + subString + (numCut == 3 ? "" : "."), result);
            }
        }
    }
}
