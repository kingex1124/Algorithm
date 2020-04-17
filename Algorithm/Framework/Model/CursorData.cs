using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Framework.Model
{
    public class CursorData
    {
        /// <summary>
        /// 資料
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// 游標，為0時表示無指向
        /// </summary>
        public int cur { get; set; }

        /// <summary>
        /// 存取最後一個空值得index
        /// </summary>
        public int last { get; set; }
    }
}
