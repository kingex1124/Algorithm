using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class StringReverse
    {
        public StringReverse()
        {

        }

        public string Reverse(string str)
        {
            return str.ToArray().Aggregate("", (rev, cha) => rev = cha + rev);
        }

        public string Reverse1(string str)
        {          
            string rev = string.Empty;

            foreach (var cha in str)
                rev = cha + rev;
            return rev;
        }
    }
}
