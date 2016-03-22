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
    public class SubjectSortManager
    {
        private SubjectSortService Service = ObjectContainer.GetInstance<SubjectSortService>();
        public OutputModel Add(SubjectSortTsfer subsort)
        {
            if (subsort == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Get(subsort.Name) != null)
                return OutputHelper.GetOutputResponse(ResultCode.DataExisted);
            if (Service.Add(subsort))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }

        public OutputModel Update(SubjectSortTsfer subsort)
        {
            if (subsort == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Update(subsort))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }

        public OutputModel Delete(int id)
        {
            if (Service.Delete(id))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Get(int id)
        {
            SubjectSortTsfer s = Service.Get(id);
            if (s == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, s);
        }
        public OutputModel Get(string name)
        {
            SubjectSortTsfer s = Service.Get(name);
            if (s == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, s);
        }
        public OutputModel GetList()
        {
            List<SubjectSortTsfer> list = Service.GetList();
            if (list == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
