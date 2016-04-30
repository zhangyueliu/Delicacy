using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DataTransfer;
using Tool;

namespace Manager
{
    public class TasteManager
    {
        private TasteService Service = ObjectContainer.GetInstance<TasteService>();

        public OutputModel Add(TasteTsfer taste)
        {
            if (taste != null)
            {
                if (Service.Get(taste.Name) != null)
                {
                    return OutputHelper.GetOutputResponse(ResultCode.DataExisted, "口味已存在,请直接选择");
                }
                if (Service.Add(taste))
                {
                    return OutputHelper.GetOutputResponse(ResultCode.OK);
                }
                else
                {
                    return OutputHelper.GetOutputResponse(ResultCode.Error);
                }
            }
            else
            {
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            }
        }

        public OutputModel Update(string id, string name)
        {
            int i;
            if (!int.TryParse(id, out i))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
            TasteTsfer taste = Service.Get(i);
            if (taste != null)
            {
                taste.Name = name;
                if (Service.Update(taste))
                {
                    return OutputHelper.GetOutputResponse(ResultCode.OK);
                }
                return OutputHelper.GetOutputResponse(ResultCode.Error);
            }
            return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
        }

        public OutputModel Delete(string id)
        {
            int i;
            if (!int.TryParse(id, out i))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
            if (Service.Delete(i))
            {
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            }
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Get(int tasteId)
        {
            TasteTsfer t = Service.Get(tasteId);
            if (t == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, t);
        }
        public OutputModel Get(string name)
        {
            TasteTsfer t = Service.Get(name);
            if (t == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, t);
        }
        public OutputModel GetList(int status)
        {
            List<TasteTsfer> list = Service.GetList(status);
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        public OutputModel GetList()
        {
            List<TasteTsfer> list = Service.GetList();
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        public List<TasteTsfer> GetPage(string pageindex, int pagesize, out int pagecount)
        {
            int pageIndex;
            int rowcount;
            CheckParameter.PageCheck(pageindex, out pageIndex);
            List<TasteTsfer> list = Service.GetPage(pageIndex, pagesize, out rowcount);
            pagecount = (int)Math.Ceiling(rowcount * 1.0 / pagesize);
            return list; ;
        }
    }
}
