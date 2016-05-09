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

        public OutputModel AddCookBookComment(string cookBookId, string content, string pId, int userId, string rootId, short type)
        {
            if (CheckParameter.IsNullOrWhiteSpace(cookBookId, content, pId, rootId))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            int iPId, iRootId;
            if (!int.TryParse(pId, out iPId) || !int.TryParse(rootId, out  iRootId))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
            CommentRecordTsfer pComment = null;
            if (iPId != 0 && (pComment = service.Get(iPId)) == null)
            {
                return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied);
            }
            if (iRootId != 0 && !service.IsExist(iRootId))
                return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied);
            CommentRecordTsfer comment = new CommentRecordTsfer
            {
                Content = content,
                DateTime = DateTime.Now,
                OperateId = cookBookId,
                PId = iPId,
                Type = type,
                UserId = userId,
                RootId = iRootId,
            };

            if (service.Add(comment))
                return OutputHelper.GetOutputResponse(ResultCode.OK, "评论成功");
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
            bool b = false;
            List<CommentRecordTsfer> list = service.GetSon(id);
            if (list.Count <= 0)
                b = true;
            else
            {
                foreach (CommentRecordTsfer c in list)
                {
                    if (Delete(c.CommentId).StatusCode != 1)
                        return OutputHelper.GetOutputResponse(ResultCode.Error);
                    else
                        b = true;
                }
            }
            if (service.Delete(id) && b)
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
        public OutputModel GetListCookBook(string cookbookid, short type)
        {
            if (string.IsNullOrWhiteSpace(cookbookid))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            List<CommentRecordTsfer> list = service.GetListCookBook(cookbookid, type);
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);

            List<CommentRecordTsfer> result = new List<CommentRecordTsfer>();
            //List<CommentRecordTsfer> temp = list.Where(o => o.PId == 0).ToList();
            //找出所有的root评论
            result.AddRange(list.Where(o => o.PId == 0));
            //从数据库返回的结果集中移除root评论
            list.RemoveAll(o => o.PId == 0);
            //遍历root评论
            UserInfoService userService = new UserInfoService();
            foreach (CommentRecordTsfer item in result)
            {
                item.User = userService.Get(item.UserId);

                item.SonComment = list.Where(o => o.RootId == item.CommentId).ToList();
                item.SonComment.ForEach(o =>
                {
                    o.User = userService.Get(o.UserId);
                });
                list.RemoveAll(o => o.RootId == item.CommentId);
            }

            //UserInfoService userService=new UserInfoService();
            //foreach (CommentRecordTsfer  item in list)
            //{
            //    item.User = userService.Get(item.UserId);
            //}
            return OutputHelper.GetOutputResponse(ResultCode.OK, result);
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
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        public List<CommentRecordTsfer> GetPage(short type, string pageindex, int pagesize, out int pagecount)
        {

            int p;
            int rowcount;
            CheckParameter.PageCheck(pageindex, out p);
            List<CommentRecordTsfer> list = service.GetPage(type, p, pagesize, out rowcount);
            pagecount = (int)Math.Ceiling(rowcount * 1.0 / pagesize);
            CookBookManager manager = new CookBookManager();
            SubjectArticleManager managersub = new SubjectArticleManager();
            if (type == 1)
            {
                foreach (CommentRecordTsfer item in list)
                {
                    OutputModel o = manager.GetCookBook(item.OperateId);
                    if (o.StatusCode == 1)
                    {
                        CookBookTsfer c = (CookBookTsfer)o.Data;
                        item.OperateName = c.Name;
                    }
                }
            }
            else if (type == 2)
            {
                foreach (CommentRecordTsfer item in list)
                {
                    OutputModel o = managersub.Get(item.OperateId);
                    if (o.StatusCode == 1)
                    {
                        SubjectArticleTsfer c = (SubjectArticleTsfer)o.Data;
                        item.OperateName = c.Title;
                    }
                }
            }
            return list;
        }

    }
}
