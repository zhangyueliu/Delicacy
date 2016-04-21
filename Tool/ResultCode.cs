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
       /// <summary>
       /// 成功
       /// </summary>
       [Description("成功")]
       OK=1,
      /// <summary>
       /// 缺少必要参数
      /// </summary>
       [Description("缺少必要参数")]
       NoParameter = 2,
      /// <summary>
       /// 参数格式错误
      /// </summary>
       [Description("参数格式错误")]
       ErrorParameter = 3,
      /// <summary>
       /// 没有数据
      /// </summary>
       [Description("没有数据")]
       NoData = 4,
      /// <summary>
       /// 没有登录
      /// </summary>
       [Description("没有登录")]
       NoLogin = 5,
       /// <summary>
       /// 条件不符合
       /// </summary>
       [Description("条件不符合")]
       ConditionNotSatisfied = 6,
       /// <summary>
       /// 已存在
       /// </summary>
       [Description("已存在")]
       DataExisted=7,

       /// <summary>
       /// 用户名或密码错误
       /// </summary>
       [Description("用户名或密码错误")]
       LoginFail=8


    }
}