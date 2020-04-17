using Algorithm.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList test = new MyList(2);
            test[1] = 5;
            test[0] = 6;

            object a=null;

            bool result = test.GetElem(1, ref a);

            Console.WriteLine(test[1].ToString());

            MyListCursor N = new MyListCursor(1000);

            N.ListAdd("甲");
            N.ListAdd("乙");
            N.ListAdd("丁");
            N.ListAdd("戊");
            N.ListAdd("己");
            N.ListAdd("庚");
     
            N.ListInsert(3, "丙");

            object o = null;
            N.GetElem(1000,ref o);

            N.ListDelete(1);

        }
    }
}
