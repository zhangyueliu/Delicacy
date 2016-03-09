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
    public class UserInfoService : BaseService<UserInfo>
    {
        public bool Add(UserInfoTsfer userInfo)
        {
            base.Add(TransferObject.ConvertObjectByEntity<UserInfoTsfer, UserInfo>(userInfo));
            return Save() > 0;
        }
        public bool Update(UserInfoTsfer userInfo)
        {
            base.Update(TransferObject.ConvertObjectByEntity<UserInfoTsfer, UserInfo>(userInfo));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
<<<<<<< HEAD

        /// <summary>
        /// 根据邮箱获取用户对象
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public UserInfoTsfer SelectByLoginId(string loginId)
=======
        public UserInfoTsfer Select(int id)
>>>>>>> 54dd0a83f93b9e673305733ec291e87730a3eb9b
        {
            UserInfoTsfer u = TransferObject.ConvertObjectByEntity<UserInfo, UserInfoTsfer>(base.Select(id));
            return u;
        }
        
    }
}
