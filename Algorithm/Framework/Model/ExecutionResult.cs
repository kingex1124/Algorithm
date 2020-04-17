using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Framework.Model
{
    public class ExecutionResult
    {
        public ExecutionResult()
        {
        }

        protected ResultCode _code = ResultCode.Success;

        protected string _Message = "";

        protected string _OtherInformation = "";

        public ResultCode Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }

        public string Message
        {
            get
            {
                if (this._Message == "")
                {
                    this._Message = ExecutionResult.GetBaseResultMessage(this._code);
                }
                return this._Message;
            }
            set
            {
                this._Message = value;
            }
        }

        public string OtherInformation
        {
            get
            {
                return this._OtherInformation;
            }
            set
            {
                this._OtherInformation = value;
            }
        }

        public static string GetBaseResultMessage(ResultCode code)
        {
            string str;
            string empty = string.Empty;
            ResultCode resultCode = code;
            switch (resultCode)
            {
                case ResultCode.Success:
                    {
                        empty = "執行成功！";
                        str = empty;
                        return str;
                    }
                case ResultCode.DataOver:
                    {
                        empty = "存取超過最大存取空間";
                        str = empty;
                        return str;
                    }
                default:
                    {
                        if (resultCode == ResultCode.Error)
                        {
                            empty = "發生內部錯誤！";
                            str = empty;
                            return str;
                        }
                        else
                        {
                            str = empty;
                            return str;
                        }
                    }
            }
        }
    }
}
