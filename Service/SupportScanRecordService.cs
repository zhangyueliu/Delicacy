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
    public class SupportScanRecordService : BaseService<SupportScanRecord>
    {
        public bool Add(SupportScanRecordTsfer support)
        {
            base.Add(TransferObject.ConvertObjectByEntity<SupportScanRecordTsfer, SupportScanRecord>(support));
            return Save() > 0;
        }
        public bool Update(SupportScanRecordTsfer support)
        {
            base.Update(TransferObject.ConvertObjectByEntity<SupportScanRecordTsfer, SupportScanRecord>(support));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public bool Delete(SupportScanRecordTsfer support)
        {
            base.Delete(TransferObject.ConvertObjectByEntity<SupportScanRecordTsfer,SupportScanRecord>(support));
            return Save() > 0;
        }
        public SupportScanRecordTsfer Get(int id)
        {
            return TransferObject.ConvertObjectByEntity<SupportScanRecord, SupportScanRecordTsfer>(base.Select(id));
        }
        /// <summary>
        /// 获取某菜谱某用户的记录
        /// </summary>
        /// <param name="cookbookid">菜谱id</param>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public SupportScanRecordTsfer Get(string  cookbookid,int userid)
        {
            return TransferObject.ConvertObjectByEntity<SupportScanRecord, SupportScanRecordTsfer>(base.Select(o=>o.CookBookId==cookbookid&&o.UserId==userid).FirstOrDefault());
        }

        /// <summary>
        ///  获取某用户的点赞记录
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="type">1为点赞</param>
        /// <returns></returns>
        public List<SupportScanRecordTsfer> GetListUser(int userid)
        {
            return TransferObject.ConvertObjectByEntity<SupportScanRecord, SupportScanRecordTsfer>(base.Select(o => o.UserId == userid).ToList());
        }
        /// <summary>
        /// 获取某菜谱点赞的列表
        /// </summary>
        /// <param name="cookbookid"></param>
        /// <param name="type">1为点赞</param>
        /// <returns></returns>
        public List<SupportScanRecordTsfer> GetListCookbook(string  cookbookid)
        {
            return TransferObject.ConvertObjectByEntity<SupportScanRecord, SupportScanRecordTsfer>(base.Select(o => o.CookBookId == cookbookid).ToList());
        }
        public List<SupportScanRecordTsfer> GetList()
        {
            return TransferObject.ConvertObjectByEntity<SupportScanRecord, SupportScanRecordTsfer>(base.Select(o => true).ToList());
        }

        /// <summary>
        /// 获取点赞数量
        /// </summary>
        /// <param name="cookBookId"></param>
        /// <returns></returns>
        public int GetSupportCount(string cookBookId)
        {
            return Select(o => o.CookBookId == cookBookId).Count();
        }

        
        public bool IsExist(string cookBookId,int userId,int type)
        {
            return Select(o => o.CookBookId == cookBookId && o.UserId == userId && o.Type == type).Any();
        }
    }
}
