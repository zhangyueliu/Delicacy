using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataTransfer
{
    public class UserInfoTsfer
    {
        public int UserId { get; set; }
        public string LoginId { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Name { get; set; }
        public System.DateTime RegisterDate { get; set; }
    }
}
