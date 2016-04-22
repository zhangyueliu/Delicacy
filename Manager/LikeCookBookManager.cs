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
        private LikeCookBookService Service = new  LikeCookBookService();
        public OutputModel Add(string cookBookId,int userId)
        {
            if (string.IsNullOrEmpty(cookBookId)||userId==0)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            //判断是否关注过
            LikeCookBookTsfer l = Service.Get(userId, cookBookId);
            if (l != null)
                return Delete(l);
            
            
            //判断菜谱是否存在
            CookBookService cookService = new CookBookService();
            if(! cookService.IsExist(cookBookId))
                return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied,"菜谱不存在");
            LikeCookBookTsfer like = new LikeCookBookTsfer { 
            CookBookId=cookBookId,
            DateTime=DateTime.Now,
            UserId=userId,
            };
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
        public OutputModel Delete(LikeCookBookTsfer like)
        {
            if (Service.Delete(like))
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
            LikeCookBookTsfer like = Service.Get(id);
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
        public OutputModel Get(int userid, string  cookbookid)
        {
            LikeCookBookTsfer like = Service.Get(userid, cookbookid);
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
        public OutputModel GetsCookbook(string  cookbookid)
        {
            List<LikeCookBookTsfer> list = Service.GetsCookbook(cookbookid);
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
