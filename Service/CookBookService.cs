using System.Data.SqlClient;
﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using DataTransfer;
using Tool;

namespace Service
{
    public class CookBookService : BaseService<CookBook>
    {
        public bool Add(CookBookTsfer cookBook, List<FoodMaterial_CookBookTsfer> listMaterCook)
        {
            //这里增加菜过程的插入
            base.Add(TransferObject.ConvertObjectByEntity<CookBookTsfer, CookBook>(cookBook));
            base.Add<CookProcess>(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookBook.ListProcess));
            base.Add<CookMaterial>(TransferObject.ConvertObjectByEntity<CookMaterialTsfer, CookMaterial>(cookBook.ListMaterial));
            Add<FoodMaterial_CookBook>(TransferObject.ConvertObjectByEntity<FoodMaterial_CookBookTsfer, FoodMaterial_CookBook>(listMaterCook));
            return Save() > 0;
        }
        public bool Update(CookBookTsfer cookBook)
        {
            base.Update(TransferObject.ConvertObjectByEntity<CookBookTsfer, CookBook>(cookBook));
            return Save() > 0;
        }
        public bool Delete(CookBookTsfer c)
        {
            base.Delete(TransferObject.ConvertObjectByEntity<CookBookTsfer,CookBook>(c));
            return Save() > 0;
        }
        public CookBookTsfer Get(string cookBookId, int status)
        {
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(base.Select(o => o.CookBookId == cookBookId && o.Status == status).FirstOrDefault());
        }

        public CookBookTsfer Get(string cookBookId)
        {
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(base.Select(o => o.CookBookId == cookBookId).FirstOrDefault());
        }

        /// <summary>
        /// 根据菜谱名称进行模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<CookBookTsfer> GetByName(string name, int status)
        {
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(Select(o => o.Name.Contains(name) && o.Status == status).ToList());
        }

        /// <summary>
        /// 根据菜谱状态获取某人的菜谱
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="userId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<CookBookTsfer> GetPage(int pageIndex,int pageSize,int userId, int status)
        {
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(SelectDesc(pageIndex,pageSize,o => o.UserId == userId && o.Status == status,o=>o.DateTime).ToList());
        }

        public List<CookBookTsfer> GetPageBySort(int sort, int pageIndex, int pageSize, int status, out int rowCount)
        {
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(SelectDesc(pageIndex, pageSize, o => o.FoodSortId == sort && o.Status == status, o => o.DateTime, out rowCount).ToList());
        }

        public List<CookBookTsfer> GetPageByFoodMaterial(int foodMaterialId, int pageIndex, int pageSize, int status, out int rowCount)
        {
            IQueryable<string> queryCookBookId = new FoodMaterial_CookBookTsferService().GetIQueryCookBookId(foodMaterialId);
            List<CookBook> list = SelectDesc(pageIndex, pageSize, o => queryCookBookId.Contains(o.CookBookId) && o.Status == status, o => o.DateTime, out rowCount).ToList();
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(list);
        }
        public List<CookBookTsfer> GetPage(int pageindex, int pagesize, int status, out int rowCount)
        {
            List<CookBook> list = SelectDesc(pageindex, pagesize, o => o.Status == status, o => o.DateTime, out rowCount).ToList();
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(list);
        }
        public List<CookBookTsfer> GetPage(int pageindex, int pagesize, out int rowCount)
        {
            List<CookBook> list = SelectDesc(pageindex, pagesize, o => true, o => o.DateTime, out rowCount).ToList();
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(list);
        }
        public bool IsExist(string cookBookId)
        {
            return Select(o => o.CookBookId == cookBookId).Any();
        }

        public bool UpdateStaus(string ids, string status)
        {
            string sql = "update CookBook set status=" + status + " where CookBookId in (" + ids + ")";
            return ExecuteCUD(sql) > 0;
        }

        /// <summary>
        /// 获取最火菜谱
        /// </summary>
        /// <param name="topNum"></param>
        /// <returns></returns>
        public List<CookBookTsfer> GetListByHottest(int topNum)
        {
            string sql="select top "+topNum+" rank=((select count (cookbookid) from supportscanrecord where cookbookid= a.cookbookid )+ (select count(operateid) from commentrecord where operateid= a.cookbookid  and type=1)) ,* from cookbook as a  order by rank desc ";
            return SqlQuery<CookBookTsfer>(sql, new SqlParameter("@topNum", topNum));
        }

        /// <summary>
        /// 获取最近菜谱
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<CookBookTsfer> GetListRecent(int num)
        {
            List<CookBook> list= Select(o => o.Status==1).OrderByDescending(o => o.DateTime).Take(num).ToList();
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(list);
        }
    }
}

