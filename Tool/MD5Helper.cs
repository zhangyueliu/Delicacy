using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public static class MD5Helper
    {
        private static int Start = 5;
        private static int Length = 5;

        /// <summary>
        /// 将字符串转换为MD5加密格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string convertToMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string rs = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)));
            rs = rs.Replace("-", "");
            return rs;
        }

        public static string GeneratePwd(string password)
        {
            string newPwd = convertToMD5(password);
            return convertToMD5(newPwd + newPwd.Substring(Start, Length));
        }

    }
}
