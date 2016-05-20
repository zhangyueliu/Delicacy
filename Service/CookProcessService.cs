
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
    public class CookProcessService : BaseService<CookProcess>
    {
        public bool Add(CookProcessTsfer cookPro)
        {
            base.Add(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookPro));
            return Save() > 0;
        }

        public bool Update(CookProcessTsfer cookPro)
        {
            base.Update(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookPro));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        /// <summary>
        /// 删除某菜谱下的做菜步骤
        /// </summary>
        /// <param name="cookbookid">菜谱id</param>
        /// <returns></returns>
        public bool Delete(List<CookProcessTsfer> list)
        {
            base.Delete(TransferObject.ConvertObjectByEntity<CookProcessTsfer,CookProcess>(list));
            return Save() > 0;
        }

        //public CookProcessTsfer Get(int id)
        //{
        //    return TransferObject.ConvertObjectByEntity<CookProcess, CookProcessTsfer>(base.Select(id));
        //}

        /// <summary>
        /// 获取某菜谱下的做菜步骤列表
        /// </summary>
        /// <param name="cookbookid"></param>
        /// <returns></returns>
        public List<CookProcessTsfer> GetList(string  cookbookid)
        {
            return TransferObject.ConvertObjectByEntity<CookProcess, CookProcessTsfer>(base.Select(o => o.CookBookId == cookbookid).OrderBy(o => o.Sort).ToList());
        }
    }
}
//=======
//﻿using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EF;
//using DataTransfer;
//using Tool;

//namespace Service
//{
//    public class CookProcessService : BaseService<CookProcess>
//    {
//        public bool Add(CookProcessTsfer cookPro)
//        {
//            base.Add(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookPro));
//            return Save() > 0;
//        }
//        public bool Update(CookProcessTsfer cookPro)
//        {
//            base.Update(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookPro));
//            return Save() > 0;
//        }
//        public bool Delete(int id)
//        {
//            base.Delete(id);
//            return Save() > 0;
//        }
//        /// <summary>
//        /// 删除某菜谱下的做菜步骤
//        /// </summary>
//        /// <param name="cookbookid">菜谱id</param>
//        /// <returns></returns>
//        public bool Delete(List<CookProcessTsfer> list)
//        {
//            base.Delete(TransferObject.ConvertObjectByEntity<CookProcessTsfer,CookProcess>(list));
//            return Save() > 0;
//        }

//        public CookProcessTsfer Get(int id)
//        {
//            return TransferObject.ConvertObjectByEntity<CookProcess, CookProcessTsfer>(base.Select(id));
//        }
//        /// <summary>
//        /// 获取某菜谱下的做菜步骤列表
//        /// </summary>
//        /// <param name="cookbookid"></param>
//        /// <returns></returns>
//        public List<CookProcessTsfer> GetList(string  cookbookid)
//        {
//            return TransferObject.ConvertObjectByEntity<CookProcess, CookProcessTsfer>(base.Select(o => o.CookBookId == cookbookid).OrderBy(o => o.Sort).ToList());
//        }
//    }
//}
//>>>>>>> b203b63077616f3d5067d0a19d132b6f64d0d53c
