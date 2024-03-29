﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tool
{
    /// <summary>
    /// 使用正则表达式了验证格式是否正确
    /// </summary>
    public static class RegExVerify
    {/// <summary>
        /// 手机的正则表达式
        /// </summary>
        private static readonly string RegexMobilePhone = "^1[3|4|5|7|8|][0-9]{9}$";

        /// <summary>
        /// 邮编的正则表达式
        /// </summary>
        private static readonly string RegexPostCode = "^[0-9]{6}$";

        /// <summary>
        /// 固定电话的正则表达式
        /// </summary>
        private static readonly string RegexTelephone = @"(^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)";

        /// <summary>
        /// 邮箱的正则表达式
        /// </summary>
        private static readonly string RegexEmail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        /// <summary>
        /// 允许图片格式
        /// </summary>
        private static readonly string[] ImgExtension = { ".jpg", ".png", ".gif", ".jpeg", ".bmp" };
        
        public static bool VerifyEmail(string email)
        {
            return Regex.IsMatch(email, RegexEmail);
        }
        
        /// <summary>
        /// 验证手机号码格式是否正确
        /// </summary>
        /// <param name="mobilePhone">手机号码</param>
        /// <returns></returns>
        public static bool VerifyMobilePhone(string mobilePhone)
        {
            return Regex.IsMatch(mobilePhone, RegexMobilePhone);
        }

        /// <summary>
        /// 验证邮政编码格式是否正确
        /// </summary>
        /// <param name="postCode"></param>
        /// <returns></returns>
        public static bool VerifyPostCode(string postCode)
        {
            return Regex.IsMatch(postCode, RegexPostCode);
        }

        /// <summary>
        /// 验证固定电话格式是否正确
        /// </summary>
        /// <param name="telephone"></param>
        /// <returns></returns>
        public static bool VerifyTelephone(string telephone)
        {
            return Regex.IsMatch(telephone, RegexTelephone);
        }

        /// <summary>
        /// 检查图片的后缀名
        /// </summary>
        /// <param name="imgExtension"></param>
        /// <returns></returns>
        public  static bool CheckImgExtension(string imgExtension)
        {
            return ImgExtension.Contains(imgExtension.ToLower());
        }
    }
}
