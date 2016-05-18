using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DataTransfer;
using Tool;
using System.Configuration;

namespace Manager
{
    public class UserInfoManager
    {
        private static string IPAddress = ConfigurationManager.AppSettings["IPAddress"];
        private UserInfoService service = ObjectContainer.GetInstance<UserInfoService>();
        private VerifyRegisterServer verifyService = ObjectContainer.GetInstance<VerifyRegisterServer>();
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="loginId">邮箱</param>
        /// <param name="password">密码</param>
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
            UserInfoTsfer uTsfer = service.GetByLoginId(loginId);
            VerifyRegisterTsfer verifyDt = new VerifyRegisterTsfer
            {
                GUID = Guid.NewGuid().ToString().Replace("-", ""),
                IsUsed = false,
                OutDate = DateTime.Now.AddDays(7.0),
                LoginId = loginId,
                Type = 1
            };
            
            if (uTsfer != null)
            {
                if (uTsfer.Status == 1)
                {
                    return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied, "此邮箱已被注册，可以直接登录");
                }else
                {
                   
                    //添加到验证表中
                    VerifyRegisterServer verifyServer = new VerifyRegisterServer();
                    if (verifyServer.Add(verifyDt))
                    {
                        EmailHelper.SendEmail("[食谱网]感谢注册食谱网,请验证邮箱" + loginId, loginId.Substring(0, loginId.IndexOf('@')) + "：您好，感谢您注册食谱网，请点击下面的链接验证您的邮箱：<a href='" + IPAddress + "/UserInfo/VerifyEmail?guid=" + verifyDt.GUID + "'>" + IPAddress + "/UserInfo/VerifyEmail?guid=" + verifyDt.GUID + "</a>该链接7天后失效。", loginId);
                        return OutputHelper.GetOutputResponse(ResultCode.OK);
                    }else
                        return OutputHelper.GetOutputResponse(ResultCode.Error);
                }
                    
            }
            
            //进行注册
            UserInfoTsfer newUser = new UserInfoTsfer { 
            LoginId=loginId,
            Name=loginId,
            Password=MD5Helper.GeneratePwd(password),
            RegisterDate=DateTime.Now,
            Status=0
            };
            if (service.Add(newUser, verifyDt))
            {
                //发邮件
                EmailHelper.SendEmail("[食谱网]感谢注册食谱网,请验证邮箱" + loginId, loginId.Substring(0, loginId.IndexOf('@')) + "：您好，感谢您注册食谱网，请点击下面的链接验证您的邮箱：<a href='" + IPAddress + "/UserInfo/VerifyEmail?guid=" + verifyDt.GUID + "'>" + IPAddress + "/UserInfo/VerifyEmail?guid=" + verifyDt.GUID + "</a>该链接7天后失效。", loginId);
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            }
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
            if (!RegExVerify.VerifyEmail(loginId))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "邮箱格式不正确");
            //获取邮箱对应的用户
            UserInfoTsfer uTsfer = service.Get(loginId);
            if (uTsfer == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData, "该邮箱未注册过，请先注册");
            if (MD5Helper.GeneratePwd(password) != uTsfer.Password)
            {
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "用户名或密码不正确");
            }
            System.Web.HttpContext.Current.Session["user"] = uTsfer;
            return OutputHelper.GetOutputResponse(ResultCode.OK, "登录成功");
        }
        /// <summary>
        /// 忘记密码,重置密码发邮件
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public OutputModel LostPwd(string loginId)
        {
            if (string.IsNullOrEmpty(loginId))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter, "邮箱不能为空");
            //判断邮箱格式是否正确
            if (!RegExVerify.VerifyEmail(loginId))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "邮箱格式不正确");
            //获取邮箱对应的用户
            UserInfoTsfer uTsfer = service.Get(loginId);
            if (uTsfer == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData, "该邮箱未注册过，请先注册");
            if (new VerifyRegisterServer().IsSend(loginId,2))
                return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied, "您的邮箱已经发送");
            VerifyRegisterTsfer verifyDt = new VerifyRegisterTsfer
            {
                GUID = Guid.NewGuid().ToString().Replace("-", ""),
                IsUsed = false,
                OutDate = DateTime.Now.AddDays(7.0),
                LoginId = loginId,
                Type=2
            };
            if(verifyService.Add(verifyDt))
            {
                //发邮件
                EmailHelper.SendEmail("[食谱网]请点击链接重置密码" + loginId, loginId.Substring(0, loginId.IndexOf('@')) + "：您好，欢迎来到食谱网，请点击下面的链接重置密码：<a href='" + IPAddress + "/UserInfo/LostPwdVerifyEmail?guid=" + verifyDt.GUID + "'>" + IPAddress + "/UserInfo/LostPwdVerifyEmail?guid=" + verifyDt.GUID + "</a>该链接7天后失效。", loginId);
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            }
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public OutputModel Update(UserInfoTsfer userInfo)
        {
            if (userInfo == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            userInfo.Password = MD5Helper.GeneratePwd(userInfo.Password);
            if(service.Update(userInfo))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public bool Delete(UserInfoTsfer userInfo)
        {
            return service.Delete(userInfo.UserId);
        }
        public OutputModel Delete(string id)
        {
            int i;
            if (!int.TryParse(id, out i))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
            if (service.Delete(i))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        /// <summary>
        /// 根据邮箱获取用户对象
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public OutputModel Get(string loginId)
        {
            UserInfoTsfer u = service.Get(loginId);
            if (u == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, u);
        }

        public List<UserInfoTsfer> GetAll()
        {
            return service.GetAll();
        }
    }
}
