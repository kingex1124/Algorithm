using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string T = "aaaaaaaab";//"ababc";//"abcabx";//"ABABCABAA"; //"aaaaaaaab";
            int[] next = new int[T.Length];
            Program ob = new Program();
            //ob.prefix_table(T, ref next, T.Length);
            //ob.get_next(T,ref next);
            string text="ABABABABCABAAB";
            string patten= "ABABCABAA";
            ob.kmp_search(text, patten);
        }

        public void prefix_table(string pattern,ref int[] prefix,int n)
        {
            prefix[0] = 0;
            int len = 0;
            int i = 1;
            while (i < n)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    prefix[i] = len;
                    i++;
                }
                else
                {
                    if (len > 0)
                    {
                        len = prefix[len - 1];
                    }
                    else
                    {
                        prefix[i] = len;
                        i++;
                    }
                }
            }
        }

        public void move_prefix_table(ref int[] prefix,int n)
        {
            for (int i = n - 1; i > 0; i--)
                prefix[i] = prefix[i - 1];
            prefix[0] = -1;
        }

        public void kmp_search(string text,string patten)
        {
            int n = patten.Length;
            int m = text.Length;
            int [] prefix = new int[n];
            this.prefix_table(patten, ref prefix, n);
            this.move_prefix_table(ref prefix, n);

            //text[i] len(text) = m
            //patten[j] len(patten) = n

            int i = 0;
            int j = 0;
            while (i<m)
            {
                if (j==n-1 && text[i]==patten[j])
                {
                    var result = i - j;
                    j = prefix[j];
                }
                if(text[i]==patten[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = prefix[j];
                    if(j==-1)
                    {
                        i++;
                        j++;
                    }
                }
            }
        }

        public void get_next(string T,ref int [] next)
        {
            int i, j;
            i = 1;
            j = 0;
            next[1] = 0;
            while (i<T.Length)
            {
                if (j == 0 || T[i] == T[j])
                {
                    j++;                  
                    i++;
                    if (i < T.Length)
                    {
                        next[i] = j;
                        if (T[i] != T[j])
                            next[i] = j;
                        else
                            next[i] = next[j];
                    }

                }
                else
                    j = next[j-1];
            }
        }
    }
}
