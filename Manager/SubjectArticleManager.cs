
﻿using System;
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
            if (service.Update(subarticle))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }

        public OutputModel Delete(string id)
        {
            int i;
            CheckParameter.PageCheck(id, out i);
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

        public OutputModel Get(int id)
        {
            SubjectArticleTsfer s = service.Get(id);
            if (s == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, s);
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
    }
}