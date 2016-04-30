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
        private TasteService service = ObjectContainer.GetInstance<TasteService>();

        public OutputModel Add(TasteTsfer taste)
        {
            if (taste != null)
            {
                if (service.Get(taste.Name) != null)
                {
                    return OutputHelper.GetOutputResponse(ResultCode.DataExisted, "口味已存在,请直接选择");
                }
                if (service.Add(taste))
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
            TasteTsfer taste = service.Get(i);
            if (taste != null)
            {
                taste.Name = name;
                if (service.Update(taste))
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
            if (service.Delete(i))
            {
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            }
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Get(int tasteId)
        {
            TasteTsfer t = service.Get(tasteId);
            if (t == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, t);
        }
        public OutputModel Get(string name)
        {
            TasteTsfer t = service.Get(name);
            if (t == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, t);
        }
        public OutputModel GetList(int status)
        {
            List<TasteTsfer> list = service.GetList(status);
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        public OutputModel GetList()
        {
            List<TasteTsfer> list = service.GetList();
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }

        public List<TasteTsfer>  GetListByStatus(int status)
        {
            return  service.GetList(status);
        }

        public List<TasteTsfer> GetPage(string pageindex, int pagesize, out int pagecount)
        {
            int pageIndex;
            int rowcount;
            CheckParameter.PageCheck(pageindex, out pageIndex);
            List<TasteTsfer> list = service.GetPage(pageIndex, pagesize, out rowcount);
            pagecount = (int)Math.Ceiling(rowcount * 1.0 / pagesize);
            return list; ;
        }
    }
}
