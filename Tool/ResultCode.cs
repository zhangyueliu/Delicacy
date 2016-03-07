using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
   public  enum ResultCode
    {
       /// <summary>
        /// 服务器繁忙，操作失败
       /// </summary>
       [Description("服务器繁忙，操作失败")]
       Error=0,
       [Description("成功")]
       OK=1,
       [Description("缺少必要参数")]
       NoParameter = 2,
       [Description("参数格式错误")]
       ErrorParameter = 3,
       [Description("没有数据")]
       NoData = 4,
       [Description("没有登录")]
       NoLogin = 5,


    }
}
