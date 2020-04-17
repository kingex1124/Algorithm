using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q242ValidAnagram
    {
        public Q242ValidAnagram()
        {

        }

        /// <summary>
        /// 學來的 Mapping解法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram4(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            Dictionary<char, int> charMap = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                charMap[s[i]] = charMap.ContainsKey(s[i]) ? charMap[s[i]] + 1 : 1;
                charMap[t[i]] = charMap.ContainsKey(t[i]) ? charMap[t[i]] - 1 : -1;
            }
       
            foreach (var ch in charMap)
                if (ch.Value < 0)
                    return false;
            return true;
        }

        /// <summary>
        /// 學來的，排序解法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram1(string s, string t)
        {
            s = string.Join("", s.ToCharArray().OrderBy(o => o));
            t = string.Join("", t.ToCharArray().OrderBy(o => o));
            //if (string.Join("", s.ToCharArray().OrderBy(o => o)) != string.Join("", t.ToCharArray().OrderBy(o => o)))
            if (s != t)
                return false;
            return true;
        }

        /// <summary>
        /// 自己寫的 Mapping解法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            Dictionary<char, int> charMap = new Dictionary<char, int>();
            foreach (var ch in s)
                charMap[ch] = charMap.ContainsKey(ch) ? charMap[ch] + 1 : 1;
            foreach (var ch in t)
                charMap[ch] = charMap.ContainsKey(ch) ? charMap[ch] - 1 : -1;
            foreach (var ch in charMap)
                if (ch.Value < 0)
                    return false;
            return true;
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram3(string s, string t)
        {
            Dictionary<char, int> schaMap = BuildMapping(s);
            Dictionary<char, int> tchaMap = BuildMapping(t);

            if (schaMap.Count != tchaMap.Count)
                return false;
            foreach (var cha in schaMap)
                if (cha.Value != (tchaMap.ContainsKey(cha.Key) ? tchaMap[cha.Key] : 0))
                    return false;
            return true;
        }

        public Dictionary<char, int> BuildMapping(string str)
        {
            Dictionary<char, int> chaMap = new Dictionary<char, int>();
            foreach (var cha in str)
                chaMap[cha] = chaMap.ContainsKey(cha) ? chaMap[cha] + 1 : 1;
            return chaMap;
        }

    }
}
