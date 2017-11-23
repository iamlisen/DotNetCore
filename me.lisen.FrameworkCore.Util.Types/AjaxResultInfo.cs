using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace me.lisen.FrameworkCore.Util.Types
{
    /// <summary>
    /// 定义公共Ajax返回信息
    /// </summary>
    public class AjaxResultInfo
    {
        public ResultType Type { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    //标识返回类型
    public enum ResultType
    {
        Error = -1,
        Success = 1,
        Warning = 2
    }
}
