using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Tool;
using DataTransfer;

namespace Manager
{
    public class LikeCookBookManager
    {
        private LikeCookBookService Service = ObjectContainer.GetInstance<LikeCookBookService>();
        public OutputModel Add(LikeCookBookTsfer like)
        {
            if (like == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Get(like.UserId, like.CookBookId) != null)
                Delete(like.LikeId);
            if (Service.Add(like))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }

        public OutputModel Delete(int id)
        {
            if (Service.Delete(id))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        /// <summary>
       /// 获取某收藏数据
       /// </summary>
       /// <param name="id">主键</param>
       /// <returns></returns>
        public OutputModel Get(int id)
        {
           LikeCookBookTsfer like= Service.Get(id);
           if (like == null)
               return OutputHelper.GetOutputResponse(ResultCode.NoData);
           return OutputHelper.GetOutputResponse(ResultCode.OK, like);
        }
         /// <summary>
       /// 获取某用户某菜谱的收藏
       /// </summary>
       /// <param name="userid">用户id</param>
       /// <param name="cookbookid">菜谱id</param>
       /// <returns></returns>
        public OutputModel Get(int userid, int cookbookid)
        {
           LikeCookBookTsfer like= Service.Get(userid, cookbookid);
           if (like == null)
               return OutputHelper.GetOutputResponse(ResultCode.NoData);
           return OutputHelper.GetOutputResponse(ResultCode.OK, like);
        }
        public OutputModel GetList()
        {
            List<LikeCookBookTsfer> list = Service.GetList();
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        /// <summary>
        /// 获取某用户的收藏
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public OutputModel GetsUser(int userid)
        {
            List<LikeCookBookTsfer> list = Service.GetsUser(userid);
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        /// <summary>
        /// 获取某菜谱的收藏列表
        /// </summary>
        /// <param name="userid">菜谱id</param>
        /// <returns></returns>
        public OutputModel GetsCookbook(int cookbookid)
        {
            List<LikeCookBookTsfer> list = Service.GetsCookbook(cookbookid);
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
