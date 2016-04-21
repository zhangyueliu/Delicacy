<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransfer;
using Service;
using Tool;

namespace Manager
{
    public class CookProcessManager
    {
        private CookProcessService Service = ObjectContainer.GetInstance<CookProcessService>();
        public OutputModel Add(CookProcessTsfer cookprocess)
        {
            if (cookprocess == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Add(cookprocess))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Update(CookProcessTsfer cookprocess)
        {
            if (cookprocess == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Update(cookprocess))
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
        /// 删除某菜谱下的做菜步骤
        /// </summary>
        /// <param name="cookbookid">菜谱id</param>
        /// <returns></returns>
        public OutputModel DeleteList(string  cookbookid)
        {
            OutputModel outputmodel = GetList(cookbookid);
            if(outputmodel.StatusCode==1)
            {
                List<CookProcessTsfer> list = (List<CookProcessTsfer>)outputmodel.Data;
                if (Service.Delete(list))
                    return OutputHelper.GetOutputResponse(ResultCode.OK);
                return OutputHelper.GetOutputResponse(ResultCode.Error);
            }
            return outputmodel;
        }
        // public OutputModel Get(int id)
        //{
        //    CookProcessTsfer c = Service.Get(id);
        //    if (c == null)
        //        return OutputHelper.GetOutputResponse(ResultCode.NoData);
        //    return OutputHelper.GetOutputResponse(ResultCode.OK, c);
        //}
        /// <summary>
        /// 获取某菜谱下的做菜步骤列表
        /// </summary>
        /// <param name="cookbookid">菜谱id</param>
        /// <returns></returns>
        public OutputModel GetList(string  cookbookid)
        {
           List<CookProcessTsfer>list= Service.GetList(cookbookid);
           if (list.Count == 0)
               return OutputHelper.GetOutputResponse(ResultCode.NoData);
           return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransfer;
using Service;
using Tool;

namespace Manager
{
    public class CookProcessManager
    {
        private CookProcessService Service = ObjectContainer.GetInstance<CookProcessService>();
        public OutputModel Add(CookProcessTsfer cookprocess)
        {
            if (cookprocess == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Add(cookprocess))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Update(CookProcessTsfer cookprocess)
        {
            if (cookprocess == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Update(cookprocess))
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
        /// 删除某菜谱下的做菜步骤
        /// </summary>
        /// <param name="cookbookid">菜谱id</param>
        /// <returns></returns>
        public OutputModel DeleteList(string  cookbookid)
        {
            OutputModel outputmodel = GetList(cookbookid);
            if(outputmodel.StatusCode==1)
            {
                List<CookProcessTsfer> list = (List<CookProcessTsfer>)outputmodel.Data;
                if (Service.Delete(list))
                    return OutputHelper.GetOutputResponse(ResultCode.OK);
                return OutputHelper.GetOutputResponse(ResultCode.Error);
            }
            return outputmodel;
        }
         public OutputModel Get(int id)
        {
            CookProcessTsfer c = Service.Get(id);
            if (c == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, c);
        }
        /// <summary>
        /// 获取某菜谱下的做菜步骤列表
        /// </summary>
        /// <param name="cookbookid">菜谱id</param>
        /// <returns></returns>
        public OutputModel GetList(string  cookbookid)
        {
           List<CookProcessTsfer>list= Service.GetList(cookbookid);
           if (list.Count == 0)
               return OutputHelper.GetOutputResponse(ResultCode.NoData);
           return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
>>>>>>> b203b63077616f3d5067d0a19d132b6f64d0d53c
