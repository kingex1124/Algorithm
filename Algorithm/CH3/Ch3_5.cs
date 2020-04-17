using Algorithm.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH3
{
    public class Ch3_5
    {
        public bool GetElem(MyList L,int i ,ref object e)
        {
            if (L.Length == 0 || i < 0 || i > L.Length)
                return false;
            e = L[i];

            return true;
        }

        public bool ListInsert(MyList l,int i,object o)
        {
            int k;
            if (l.Length == l.MaxSize)
                return false;

            if (i < 0 || i > l.Length-1)
                return false;

            if (i <= l.Length)
            {
                for (k = l.Length - 1; k > i ; k--)
                    l[k + 1] = l[k];
            }
            l[i] = o;
            return true;
        }

        public bool ListDeleteByIndex(MyList l,int i ,ref object o)
        {
            int k;
            if (l.Length == 0)
                return false;
            if (i < 0 || i > l.Length-1)
                return false;
            o = l[i];
            if (i < l.Length - 1)
            {
                for (k = i; k <= l.Length-1; k++)
                    l[k] = l[k+1];
            }
            l[l.Length-1] = null;
            return true;
        }


    }
}
