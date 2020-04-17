using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class lintcodeQ680SplitString
    {
        public lintcodeQ680SplitString()
        {
            //var result = ob.splitString("12345");
        }

        public List<List<String>> splitString(String s)
        {
            List<List<String>> result = new List<List<String>>() { };
            var word = s.ToCharArray();
            List<string> temp = new List<string>();
            foreach (var item in word)
                temp.Add(item.ToString());
            helper(word, 0, temp, result);
            return result;
        }

        public void helper(char[] word, int offset, List<string> subset, List<List<string>> result)
        {
            result.Add(subset.ToList());

            for (int i = offset; i < word.Length; i++)
            {
                var tempSubset = subset.ToList();
                if (i + 1 < subset.Count)
                {
                    tempSubset.Insert(i + 1, subset[i] + subset[i + 1]);
                    tempSubset.RemoveAt(i);
                    tempSubset.RemoveAt(i + 1);
                }
                else
                    continue;
                helper(word, i + 1, tempSubset.ToList(), result);
            }
        }
    }
}
