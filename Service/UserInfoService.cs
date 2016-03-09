﻿using System;
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
        public UserInfoTsfer Select(int id)
        {
            UserInfoTsfer u = TransferObject.ConvertObjectByEntity<UserInfo, UserInfoTsfer>(base.Select(id));
            return u;
        }
        
    }
}
