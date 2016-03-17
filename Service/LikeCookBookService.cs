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
   public class LikeCookBookService:BaseService<LikeCookBook>
    {
       public bool Add(LikeCookBookTsfer like)
        {
            base.Add(TransferObject.ConvertObjectByEntity<LikeCookBookTsfer, LikeCookBook>(like));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public LikeCookBookTsfer Get(int id)
        {
            return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(id));
        }
       /// <summary>
       /// 获取某用户某菜谱的收藏
       /// </summary>
       /// <param name="userid">用户id</param>
       /// <param name="cookbookid">菜谱id</param>
       /// <returns></returns>
       public LikeCookBookTsfer Get(int userid,int cookbookid)
        {
            return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(o => o.UserId == userid&&o.CookBookId==cookbookid).FirstOrDefault());
        }
       /// <summary>
       /// 获取某用户的收藏
       /// </summary>
       /// <param name="userid">用户id</param>
       /// <returns></returns>
       public List<LikeCookBookTsfer> Gets(int userid)
       {
           return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(o => o.UserId == userid).ToList());
       }

       public List<LikeCookBookTsfer> GetList()
       {
           return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(o => true).ToList());
       }
    }
}
