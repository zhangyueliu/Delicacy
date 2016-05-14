using Service;
using DataTransfer;
using Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Manager
{
    public class AdminUserManager
    {
        private AdminUserService service = new AdminUserService();

        public OutputModel Login(string userId, string pwd)
        {
            if (CheckParameter.IsNullOrEmpty(userId, pwd))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            AdminUserTsfer user = service.Get(userId, MD5Helper.GeneratePwd(pwd));
            if (user == null)
                return OutputHelper.GetOutputResponse(ResultCode.LoginFail, "账号或密码不正确");
            HttpContext.Current.Session["adminUser"] = user;
            return OutputHelper.GetOutputResponse(ResultCode.OK);

        }
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
        public OutputModel Add(string userId, string md5Pwd)
        {
            if (CheckParameter.IsNullOrWhiteSpace(userId, md5Pwd))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            AdminUserTsfer adminUser = new AdminUserTsfer
            {
                pwd = Tool.MD5Helper.GeneratePwd(md5Pwd),
                UserId = userId,
                RegDate = DateTime.Now
            };
            if (service.Add(adminUser))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            else
                return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public bool Update(AdminUserTsfer user)
        {
            return service.Update(user);
        }


    }
}
