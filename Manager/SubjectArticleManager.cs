
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
        public OutputModel Add(string  content,string userId)
        {
            if (string.IsNullOrWhiteSpace(content))
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            SubjectArticleTsfer article = new SubjectArticleTsfer {
            Content=content,
            Datetime=DateTime.Now,
            SubjectSortId=-1,
            UserId=userId
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
        public OutputModel Delete(int id)
        {
            if (service.Delete(id))
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
            if(outputmodel.StatusCode==1)
            {
                List<SubjectArticleTsfer> list =(List <SubjectArticleTsfer>)outputmodel.Data;
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
        public OutputModel GetList()
        {
            List<SubjectArticleTsfer> list = service.GetList();
            if (list == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
//=======
//﻿using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Tool;
//using DataTransfer;
//using Service;

//namespace Manager
//{
//    public class SubjectArticleManager
//    {
//        private SubjectArticleService Service = ObjectContainer.GetInstance<SubjectArticleService>();
//        public OutputModel Add(SubjectArticleTsfer subarticle)
//        {
//            if (subarticle == null)
//                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
//            if (Service.Add(subarticle))
//                return OutputHelper.GetOutputResponse(ResultCode.OK);
//            return OutputHelper.GetOutputResponse(ResultCode.Error);
//        }
//        public OutputModel Update(SubjectArticleTsfer subarticle)
//        {
//            if (subarticle == null)
//                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
//            if (Service.Update(subarticle))
//                return OutputHelper.GetOutputResponse(ResultCode.OK);
//            return OutputHelper.GetOutputResponse(ResultCode.Error);
//        }
//        public OutputModel Delete(int id)
//        {
//            if (Service.Delete(id))
//                return OutputHelper.GetOutputResponse(ResultCode.OK);
//            return OutputHelper.GetOutputResponse(ResultCode.Error);
//        }
//        /// <summary>
//        /// 删除某分类下的专题列表
//        /// </summary>
//        /// <param name="sortid"></param>
//        /// <returns></returns>
//        public OutputModel DeleteList(int sortid)
//        {
//            OutputModel outputmodel = GetSubSort(sortid);
//            if(outputmodel.StatusCode==1)
//            {
//                List<SubjectArticleTsfer> list =(List <SubjectArticleTsfer>)outputmodel.Data;
//                if (Service.DeleteList(list))
//                    return OutputHelper.GetOutputResponse(ResultCode.OK);
//                return OutputHelper.GetOutputResponse(ResultCode.Error);
//            }
//            return outputmodel;
//        }
//        public OutputModel Get(int id)
//        {
//            SubjectArticleTsfer s = Service.Get(id);
//            if (s == null)
//                return OutputHelper.GetOutputResponse(ResultCode.NoData);
//            return OutputHelper.GetOutputResponse(ResultCode.OK, s);
//        }

//        /// <summary>
//        /// 获取某用户下的专题
//        /// </summary>
//        /// <param name="userid"></param>
//        /// <returns></returns>
//        public OutputModel GetUsers(int userid)
//        {
//            List<SubjectArticleTsfer> list = Service.GetUsers(userid);
//            if (list == null)
//                return OutputHelper.GetOutputResponse(ResultCode.NoData);
//            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
//        }

//        /// <summary>
//        /// 获取分类下的饮食专题
//        /// </summary>
//        /// <param name="subjectsortid">分类id</param>
//        /// <returns></returns>
//        public OutputModel GetSubSort(int subjectsortid)
//        {
//            List<SubjectArticleTsfer> list = Service.GetSubSort(subjectsortid);
//            if (list == null)
//                return OutputHelper.GetOutputResponse(ResultCode.NoData);
//            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
//        }
//        public OutputModel GetList()
//        {
//            List<SubjectArticleTsfer> list = Service.GetList();
//            if (list == null)
//                return OutputHelper.GetOutputResponse(ResultCode.NoData);
//            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
//        }
//    }
//}
//>>>>>>> 6752f2e59eb4152301c2a1bc85605f7e003cdd22
