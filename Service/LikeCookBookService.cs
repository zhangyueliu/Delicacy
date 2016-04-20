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
    public class LikeCookBookService : BaseService<LikeCookBook>
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
        public bool Delete(LikeCookBookTsfer like)
        {
            base.Delete(TransferObject.ConvertObjectByEntity<LikeCookBookTsfer, LikeCookBook>(like));
            return Save() > 0;
        }
        /// <summary>
        /// 获取某收藏数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
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
        public LikeCookBookTsfer Get(int userid, string  cookbookid)
        {
            return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(o => o.UserId == userid && o.CookBookId == cookbookid).FirstOrDefault());
        }
        /// <summary>
        /// 获取某用户的收藏
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public List<LikeCookBookTsfer> GetsUser(int userid)
        {
            return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(o => o.UserId == userid).ToList());
        }

        /// <summary>
        /// 获取某菜谱的收藏列表
        /// </summary>
        /// <param name="userid">菜谱id</param>
        /// <returns></returns>
        public List<LikeCookBookTsfer> GetsCookbook(string  cookbookid)
        {
            return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(o => o.CookBookId == cookbookid).ToList());
        }
        public List<LikeCookBookTsfer> GetList()
        {
            return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(o => true).ToList());
        }
    }
}
