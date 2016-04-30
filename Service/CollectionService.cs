using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using DataTransfer;
using Tool;
using System.Data.SqlClient;

namespace Service
{
    public class CollectionService : BaseService<Collection>
    {
        public bool Add(CollectionTsfer collection)
        {
            base.Add(TransferObject.ConvertObjectByEntity<CollectionTsfer, Collection>(collection));
            return Save() > 0;
        }
        public new bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public bool Delete(string cookbookid,int userid)
        {
            string sql="delete from [Collection] where userid=@userid and operateid=@operateid";
            SqlParameter[] param = { 
                                   new SqlParameter( "@userid", userid ),
                                   new SqlParameter( "@operateid", cookbookid )
                                   };
            return ExecuteCUD(sql,param) > 0;
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
            return TransferObject.ConvertObjectByEntity<Collection, CollectionTsfer>(base.Select(o => o.UserId == userid && o.OperateId == cookbookid&&o.Type==1).FirstOrDefault());
        }
        /// <summary>
        /// 获取某用户的收藏
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public List<CollectionTsfer> GetsUser(int pageIndex,int pageSize,int userid)
        {
            return TransferObject.ConvertObjectByEntity<Collection, CollectionTsfer>(base.SelectDesc(pageIndex,pageSize, o => o.UserId == userid,o=>o.DateTime).ToList());
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

        /// <summary>
        /// 判断某人是否收藏过菜谱
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cookBookId"></param>
        /// <returns></returns>
        public bool IsExist(int userId,string cookBookId)
        {
            return Select(o => o.UserId == userId && o.OperateId == cookBookId && o.Type == 1).Any();
        }
    }
}
