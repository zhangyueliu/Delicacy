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
        public bool Register(string loginId,string password)
        {
            if(string.IsNullOrEmpty(loginId)||string.IsNullOrEmpty(password))
            {
                //if (!Regex.IsMatch(m.Username, "^[a-zA-Z0-9_]{2,20}$")) return "用户名格式不正确";
                //if (!Regex.IsMatch(m.Password, "^[a-zA-Z0-9_]{6,20}$")) return "密码格式不正确";
                //if (!Regex.IsMatch(m.Mobile, "^[0-9]{11}$")) return "手机格式不正确";
                //if (!Regex.IsMatch(m.Email, @"^[0-9a-zA-Z_\-\.]+@[0-9a-zA-z_\-]+\.[0-9a-zA-Z_\-]+$")) return "邮箱格式不正确";
            }

            return true;
        }
    }
}
