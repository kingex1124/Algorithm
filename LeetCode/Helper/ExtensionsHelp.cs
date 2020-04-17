using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Helper
{
    public static class ExtensionsHelp
    {
        public static string Slice(this string s,
            int beginIndex, int endIndex)
        {
            if (s == null) return null;

            return beginIndex >= 0 ?
                s.Substring(beginIndex, endIndex) :
                s.Substring(s.Length - beginIndex);
        }

        public static string Slice(this string s,
            int beginIndex = 0)
        {
            if (s == null) return null;

            return Slice(s, beginIndex, s.Length);
        }

        public static Array Slice(this Array a, int beginIndex = 0)
        {
            if (a == null || a.Length == 0) return a;

            return Slice(a, beginIndex, a.Length);
        }

        public static Array Slice(this Array a,
            int beginIndex, int endIndex)
        {
            if (a == null || a.Length == 0) return a;

            var e = Enumerable.Cast<object>(a);

            return beginIndex >= 0 ?
                e.Skip(beginIndex).ToArray() :
                e.Skip(e.Count() - beginIndex).ToArray();
        }

        public static IEnumerable<T> Slice<T>(this IEnumerable<T> e,
int beginIndex, int endIndex)
        {
            if (e == null || e.Count() == 0) return e;
            return beginIndex >= 0 ?
                e.Take(endIndex).Skip(beginIndex) :
                e.Skip(e.Count() - beginIndex);
        }

        public static List<T> Slice<T>(this List<T> e,
int beginIndex, int endIndex)
        {
            if (e == null || e.Count() == 0) return e;
            return beginIndex >= 0 ?
                e.Take(endIndex).Skip(beginIndex).ToList() :
                e.Skip(e.Count() - beginIndex).ToList();
        }
    }
}
