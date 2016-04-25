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
        public bool Add(UserInfoTsfer userInfo, VerifyRegisterTsfer verifyDt)
        {
            base.Add<VerifyRegister>(TransferObject.ConvertObjectByEntity<VerifyRegisterTsfer, VerifyRegister>(verifyDt));
            base.Add(TransferObject.ConvertObjectByEntity<UserInfoTsfer, UserInfo>(userInfo));
            return Save() > 0;
        }
        public bool Update(UserInfoTsfer userInfo, VerifyRegisterTsfer verifyDt)
        {
            base.Update<VerifyRegister>(TransferObject.ConvertObjectByEntity<VerifyRegisterTsfer, VerifyRegister>(verifyDt));
            base.Update(TransferObject.ConvertObjectByEntity<UserInfoTsfer, UserInfo>(userInfo));
            return Save() > 0;
        }

        public bool Update(UserInfoTsfer userInfo)
        {
            base.Update(TransferObject.ConvertObjectByEntity<UserInfoTsfer, UserInfo>(userInfo));
            return Save() > 0;
        }

        public new  bool  Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }


        /// <summary>
        /// 根据邮箱获取用户对象
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public UserInfoTsfer Get(string loginId)
        {
            return TransferObject.ConvertObjectByEntity<UserInfo, UserInfoTsfer>(base.Select(o => o.LoginId == loginId).FirstOrDefault());
        }

        public UserInfoTsfer Get(int userId)
        {
            return TransferObject.ConvertObjectByEntity<UserInfo, UserInfoTsfer>(base.Select(o => o.UserId == userId).FirstOrDefault());
        }

        //public UserInfoTsfer GetUserInfo(string userId)
        //{
        //    return TransferObject.ConvertObjectByEntity<UserInfo, UserInfoTsfer>(Select(o => o.LoginId == userId).FirstOrDefault());
        //}

        public List<UserInfoTsfer> GetAll()
        {
            return TransferObject.ConvertObjectByEntity<UserInfo, UserInfoTsfer>(Select(o => true).ToList());
        }
    }
}
