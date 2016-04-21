using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using DataTransfer;
using Tool;

namespace Service
{
    public class AdminUserService : BaseService<AdminUser>
    {
        public AdminUserTsfer Get(string userId,string pwd)
        {
            return TransferObject.ConvertObjectByEntity<AdminUser,AdminUserTsfer>( Select(o => o.UserId == userId && o.pwd == pwd).FirstOrDefault());
        }

    }
}
