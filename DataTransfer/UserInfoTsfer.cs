using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tool;
using System.ComponentModel.DataAnnotations;
namespace DataTransfer
{
    public class UserInfoTsfer
    {
        public int UserId { get; set; }
        [Display(Name="登录ID")]
        public string LoginId { get; set; }
        [JsonIgnore]
        [Display(Name="密码")]
        public string Password { get; set; }
        [Display(Name = "名称")]
        public string Name { get; set; }
        /// <summary>
        /// 0没有验证  1已验证
        /// </summary>
       [Display(Name="验证状态")]
        public short Status { get; set; }
        public System.DateTime RegisterDate { get; set; }

    }
}
