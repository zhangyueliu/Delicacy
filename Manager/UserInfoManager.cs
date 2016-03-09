using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DataTransfer;
using Tool;

namespace Manager
{
    public class UserInfoManager
    {
        UserInfoService userService = new UserInfoService();
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="loginId">邮箱</param>
        /// <param name="password">密码</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public OutputModel Register(string loginId, string password)
        {
            
            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(password))
            {
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter, "邮箱或密码为空");
            }
            //判断邮箱是否被注册
            UserInfoTsfer uTsfer = userService.SelectByLoginId(loginId);
            if (uTsfer != null)
                return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied, "此邮箱已被注册，可以直接登录");
            //进行注册
            UserInfoTsfer newUser = new UserInfoTsfer { 
            LoginId=loginId,
            Name=loginId,
            Password=MD5Helper.GeneratePwd(password),
            RegisterDate=DateTime.Now
            };
            if (userService.Add(newUser))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            else
                return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginId">邮箱</param>
        /// <param name="password">密码</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Login(string loginId, string password, out string msg)
        {
            msg = "";
            return true;
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool Update(UserInfoTsfer userInfo)
        {
            return userService.Update(userInfo);
        }
        public bool Delete(UserInfoTsfer userInfo)
        {
            return userService.Delete(userInfo.UserId);
        }
    }
}
