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
    public class CollectionService : BaseService<Collection>
    {
        public bool Add(CollectionTsfer like)
        {
            base.Add(TransferObject.ConvertObjectByEntity<CollectionTsfer, Collection>(like));
            return Save() > 0;
        }
        public new bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public bool Delete(CollectionTsfer like)
        {
            base.Delete(TransferObject.ConvertObjectByEntity<CollectionTsfer, Collection>(like));
            return Save() > 0;
        }
        /// <summary>
        /// 获取某收藏数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public CollectionTsfer Get(int id)
        {
            return TransferObject.ConvertObjectByEntity<Collection, CollectionTsfer>(base.Select(id));
        }
        /// <summary>
        /// 获取某用户某菜谱的收藏
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="cookbookid">菜谱id</param>
        /// <returns></returns>
        public CollectionTsfer Get(int userid, string  cookbookid)
        {
            return TransferObject.ConvertObjectByEntity<Collection, CollectionTsfer>(base.Select(o => o.UserId == userid && o.OperateId == cookbookid).FirstOrDefault());
        }
        /// <summary>
        /// 获取某用户的收藏
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public List<CollectionTsfer> GetsUser(int userid)
        {
            return TransferObject.ConvertObjectByEntity<Collection, CollectionTsfer>(base.Select(o => o.UserId == userid).ToList());
        }

        /// <summary>
        /// 获取某菜谱的收藏列表
        /// </summary>
        /// <param name="userid">菜谱id</param>
        /// <returns></returns>
        public List<CollectionTsfer> GetsCookbook(string  cookbookid)
        {
            return TransferObject.ConvertObjectByEntity<Collection, CollectionTsfer>(base.Select(o => o.OperateId == cookbookid).ToList());
        }
        public List<CollectionTsfer> GetList()
        {
            return TransferObject.ConvertObjectByEntity<Collection, CollectionTsfer>(base.Select(o => true).ToList());
        }
    }
}
