using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DataTransfer;

namespace Manager
{
    public class UserInfoManager
    {
        UserInfoService bll = new UserInfoService();
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="loginId">邮箱</param>
        /// <param name="password">密码</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Register(string loginId, string password, out string msg)
        {
            msg = "";
            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(password))
            {
                //怎么个所谓的邮箱注册
                //if (!Regex.IsMatch(m.Username, "^[a-zA-Z0-9_]{2,20}$")) return "用户名格式不正确";
                //if (!Regex.IsMatch(m.Password, "^[a-zA-Z0-9_]{6,20}$")) return "密码格式不正确";
                //if (!Regex.IsMatch(m.Mobile, "^[0-9]{11}$")) return "手机格式不正确";
                //if (!Regex.IsMatch(m.Email, @"^[0-9a-zA-Z_\-\.]+@[0-9a-zA-z_\-]+\.[0-9a-zA-Z_\-]+$")) return "邮箱格式不正确";
                msg = "邮箱或密码不能为空";
                return false;
            }
            //bll.Select()

            return true;
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
            return bll.Update(userInfo);
        }
        public bool Delete(UserInfoTsfer userInfo)
        {
            return bll.Delete(userInfo.UserId);
        }
    }
}
