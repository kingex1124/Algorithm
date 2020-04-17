using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q005LongestPalindromicSubstring
    {
        public Q005LongestPalindromicSubstring()
        {
            //代值用
            // var result = ob.LongestPalindrome("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth");
            //var result = ob.LongestPalindrome("cbbd");
        }
        public string LongestPalindrome(string s)
        {          
            string result = "";

            if (s.Length > 1000)
                return result;
                
            //寬度
            int d = 0;
            for (int j = 0; j < s.Length; j++)
            {
                //中央型
                d = CheckString(s, j, 0);
                if ((result.Length % 2 > 0 ? result.Length / 2 + 1 : result.Length / 2) < d)
                    result = s.Substring(j - ((d - 1) < 0 ? 0 : d - 1), d + d - 1);
                //對稱型
                d = CheckString(s, j, 1);
                if ((result.Length % 2 > 0 ? result.Length / 2 + 1 : result.Length / 2) <= d)
                    result = s.Substring(j - d + 1, d + d);
            }

            return result;
        }

        private int CheckString(string s, int j, int k)
        {
            int d = 0;
            while ((j - d) >= 0 && (j + d + k) < s.Length && s[j - d] == s[j + d + k])
                d++;
            
            return d;
        }
    }
}
