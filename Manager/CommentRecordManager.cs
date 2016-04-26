using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;
using Service;
using DataTransfer;

namespace Manager
{
    public class CommentRecordManager
    {
        private CommentRecordService service = ObjectContainer.GetInstance<CommentRecordService>();
        
        public OutputModel AddCookBookComment(string cookBookId,string content,string pId,int userId)
        {
            if (CheckParameter.IsNullOrWhiteSpace(cookBookId,content,pId))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            int iPId;
            if(!int.TryParse(pId,out iPId))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
            CommentRecordTsfer pComment=null;
            if (iPId != 0 && (pComment= service.Get(iPId))==null)
            {
                return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied);
            }
            CommentRecordTsfer comment = new CommentRecordTsfer { 
            Content=content,
            DateTime=DateTime.Now,
            OperateId=cookBookId,
            PId = iPId,
            Type=1,
            UserId=userId,
            RootId=iPId==0?0:pComment.RootId,
            };

            if (service.Add(comment))
                return OutputHelper.GetOutputResponse(ResultCode.OK,"评论成功");
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Update(CommentRecordTsfer comment)
        {
            if (comment == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (service.Update(comment))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Delete(int id)
        {
            if (service.Delete(id))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
         public OutputModel Get(int id)
        {
            CommentRecordTsfer c = service.Get(id);
            if (c == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, c);
        }

        /// <summary>
        /// 获取子评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OutputModel Gets(int id)
        {
            List<CommentRecordTsfer> list = service.Gets(id);
            if (list == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        /// <summary>
        /// 获取某菜谱的评论
        /// </summary>
        /// <param name="cookbookid"></param>
        /// <returns></returns>
        public OutputModel GetListCookBook(string  cookbookid)
        {
            if(string.IsNullOrWhiteSpace(cookbookid))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            List<CommentRecordTsfer> list = service.GetListCookBook(cookbookid);
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            UserInfoService userService=new UserInfoService();
            foreach (CommentRecordTsfer  item in list)
            {
                item.User = userService.Get(item.UserId);
            }
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        /// <summary>
        /// 获取某用户的所有评论
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public OutputModel GetListUser(int userid)
        {
            List<CommentRecordTsfer> list = service.GetListUser(userid);
            if (list == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK,list);
        }

        
    }
}
