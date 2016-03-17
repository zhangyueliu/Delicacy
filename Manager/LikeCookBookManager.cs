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
        private LikeCookBookService Service = ObjectContainer.GetInstance<LikeCookBookService>();
        public OutputModel Add(LikeCookBookTsfer like)
        {
            if (like == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Get(like.UserId, like.CookBookId) != null)
                return OutputHelper.GetOutputResponse(ResultCode.DataExisted);
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
        public OutputModel GetList()
        {
            List<LikeCookBookTsfer> list = Service.GetList();
            if (list.Count == 0)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
