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

        public OutputModel Update(TasteTsfer taste)
        {
            if (taste != null)
            {
                if (Service.Update(taste))
                {
                    return OutputHelper.GetOutputResponse(ResultCode.OK);
                }
                return OutputHelper.GetOutputResponse(ResultCode.Error);
            }
            return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
        }

        public OutputModel Delete(int id)
        {
            if (Service.Delete(id))
            {
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            }
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }

        public OutputModel GetList(int status)
        {
            List<TasteTsfer> list = Service.GetList(status);
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
        public OutputModel GetAll()
        {
            List<TasteTsfer> list = Service.GetList();
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
