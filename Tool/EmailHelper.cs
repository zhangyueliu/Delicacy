using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Tool
{
    public static class EmailHelper
    {
        private static readonly string EmailName = ConfigurationManager.AppSettings["EmailName"];
        private static readonly string Password = ConfigurationManager.AppSettings["Password"];

        public static bool SendEmail(string title,string body,string to)
        {
            if (string.IsNullOrEmpty(to))
                return false;
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = "smtp.163.com";//指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(EmailName, Password);//用户名和密码
            MailMessage _mailMessage = new MailMessage(EmailName, to);
            _mailMessage.Subject = title;//主题
            _mailMessage.Body = body;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.Normal;//优先级
            _smtpClient.Send(_mailMessage);
            return true;
        }
    }
}
