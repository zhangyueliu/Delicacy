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
        private UserInfoService userService = ObjectContainer.GetInstance<UserInfoService>();
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
            //判断邮箱格式是否正确
            if (!RegExVerify.VerifyEmail(loginId))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "邮箱格式不正确");
            //判断邮箱是否被注册
            UserInfoTsfer uTsfer = userService.SelectByLoginId(loginId);
            if (uTsfer != null)
                return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied, "此邮箱已被注册，可以直接登录");
            //进行注册
            UserInfoTsfer newUser = new UserInfoTsfer { 
            LoginId=loginId,
            Name=loginId,
            Password=MD5Helper.GeneratePwd(password),
            RegisterDate=DateTime.Now,
            Status=0
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
        /// <returns></returns>
        public OutputModel Login(string loginId, string password)
        {
            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(password))
            {
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter, "邮箱或密码为空");
            }
            //判断邮箱格式是否正确
            //获取邮箱对应的用户
            UserInfoTsfer uTsfer = userService.SelectByLoginId(loginId);
            if (uTsfer == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData, "该邮箱未注册过，请先注册");
            if (MD5Helper.GeneratePwd(password) != uTsfer.Password)
            {
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "密码不正确");
            }
            return OutputHelper.GetOutputResponse(ResultCode.OK, "登录成功");
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
