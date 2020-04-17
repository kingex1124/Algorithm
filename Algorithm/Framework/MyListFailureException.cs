using Algorithm.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Framework
{
    public class MyListFailureException : Exception
    {
        private ResultCode _resultCode;

        public ResultCode MyListResultCode
        {
            get
            {
                return this._resultCode;
            }
        }

        public MyListFailureException(string message, ResultCode resultCode) : base(message)
        {
            this._resultCode = resultCode;
        }
    }
}
