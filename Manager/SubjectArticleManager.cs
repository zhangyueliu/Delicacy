using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;
using DataTransfer;
using Service;

namespace Manager
{
    public class SubjectArticleManager
    {
        private SubjectArticleService service = new SubjectArticleService();

        public OutputModel Add(string content, string userId, string title, string brief)
        {
            if (CheckParameter.IsNullOrWhiteSpace(content, title, brief))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            SubjectArticleTsfer article = new SubjectArticleTsfer
            {
                Content = content,
                Datetime = DateTime.Now,
                SubjectSortId = -1,
                UserId = userId,
                Title = title,
                Brief = brief
            };
            if (service.Add(article))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }

        public OutputModel Update(SubjectArticleTsfer subarticle)
        {
            if (subarticle == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);

            SubjectArticleTsfer article = service.Get(subarticle.SubjectArticleId);
            if(article==null)
                return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied);
            article.Brief = subarticle.Brief;
            article.Content = subarticle.Content;
            article.Title = subarticle.Title;
            article.Datetime = DateTime.Now;
            if (service.Update(article))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }

        public OutputModel Delete(string id)
        {
            int i;
            if (!int.TryParse(id, out i))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
            if (!service.IsExist(i))
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            if (service.Delete(i))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }

        /// <summary>
        /// 删除某分类下的专题列表
        /// </summary>
        /// <param name="sortid"></param>
        /// <returns></returns>
        public OutputModel DeleteList(int sortid)
        {
            OutputModel outputmodel = GetSubSort(sortid);
            if (outputmodel.StatusCode == 1)
            {
                List<SubjectArticleTsfer> list = (List<SubjectArticleTsfer>)outputmodel.Data;
                if (service.DeleteList(list))
                    return OutputHelper.GetOutputResponse(ResultCode.OK);
                return OutputHelper.GetOutputResponse(ResultCode.Error);
            }
            return outputmodel;
        }

        public OutputModel Get(string id)
        {
            int i;
            if (!int.TryParse(id, out i))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
            SubjectArticleTsfer s = service.Get(i);
            if (s == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, s);
        }

        public SubjectArticleTsfer GetArticle(int  id)
         {
            SubjectArticleTsfer article=  service.Get(id);
            //article.Content = System.Web.HttpUtility.HtmlDecode(article.Content); //System.Web.HttpUtility.HtmlEncode(article.Content);
            return article;
        }

        ///// <summary>
        ///// 获取某用户下的专题
        ///// </summary>
        ///// <param name="userid"></param>
        ///// <returns></returns>
        //public OutputModel GetUsers(int userid)
        //{
        //    List<SubjectArticleTsfer> list = service.GetUsers(userid);
        //    if (list == null)
        //        return OutputHelper.GetOutputResponse(ResultCode.NoData);
        //    return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        //}

        /// <summary>
        /// 获取分类下的饮食专题
        /// </summary>
        /// <param name="subjectsortid">分类id</param>
        /// <returns></returns>
        public OutputModel GetSubSort(int subjectsortid)
        {
            List<SubjectArticleTsfer> list = service.GetSubSort(subjectsortid);
            if (list == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }

        public List<SubjectArticleTsfer> GetList()
        {
            List<SubjectArticleTsfer> list = service.GetList();
            return list;
        }

        public List<SubjectArticleTsfer> GetPage(int pageIndex, int pageSize, out int pageCount)
        {
            int count;
            List<SubjectArticleTsfer> list = service.GetPage(pageIndex, pageSize, out count);
            pageCount = (int)Math.Ceiling(count * 1.0 / pageSize);
            return list;
        }

        public List<SubjectArticleTsfer> GetRecent(int num)
        {
            return  service.GetListRecent(num);
        }
        public OutputModel GetPage(string pageIndex, string pageSize)
        {
            int count;
            int index, size;
            CheckParameter.PageCheck(pageIndex, pageSize, out index, out size);
            List<SubjectArticleTsfer> list = service.GetPage(index, size, out count);
            if (list.Count <= 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}