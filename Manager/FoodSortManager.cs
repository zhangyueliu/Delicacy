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
    public class FoodSortManager
    {
        private FoodSortService Service = ObjectContainer.GetInstance<FoodSortService>();
        public OutputModel Add(FoodSortTsfer foodsort)
        {
            if (foodsort == null)
            {
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            }
            if (Service.Get(foodsort.Name) != null)
            {
                return OutputHelper.GetOutputResponse(ResultCode.DataExisted);
            }
            if (Service.Add(foodsort))
            {
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            }
            else
            {
                return OutputHelper.GetOutputResponse(ResultCode.Error);
            }
        }
        public OutputModel Update(FoodSortTsfer foodsort)
        {
            if (foodsort == null)
            {
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            }
            if (Service.Update(foodsort))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Delete(int id)
        {
            if (Service.Delete(id))
            {
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            }
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public string Get(string id)
        {
            int i;
            CheckParameter.PageCheck(id, out i);
            FoodSortTsfer f = Service.Get(i);
            return f.Name;
        }

        public OutputModel GetList()
        {
          List<FoodSortTsfer>list=  Service.GetList();
          if (list.Count == 0)
              return OutputHelper.GetOutputResponse(ResultCode.NoData);
          return OutputHelper.GetOutputResponse(ResultCode.OK,list);
        }
    }
}
