using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH3.Model
{
    public class ListType
    {
        public int MaxSize { get; set; }

        public object[] Date
        {
            get
            {
                return Date;
            }
            set
            {
                value = new object[MaxSize];
            }
        }

        public int Length { get; set; }
    }
}
