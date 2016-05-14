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
    public class FoodMaterialManager
    {
        private FoodMaterialService service = new FoodMaterialService();

        public List<FoodMaterialTsfer> GetList()
        {
            return service.GetList();
        }
        public FoodMaterialTsfer Get(string id)
        {
            int i;
            CheckParameter.PageCheck(id, out i);
            return service.Get(i);
        }
        public List<FoodMaterialTsfer> GetPage(string pageindex, int pagesize, out int pagecount)
        {
            int pageIndex;
            int rowcount;
            CheckParameter.PageCheck(pageindex, out pageIndex);
            List<FoodMaterialTsfer> list = service.GetPage(pageIndex, pagesize, out rowcount);
            pagecount = (int)Math.Ceiling(rowcount * 1.0 / pagesize);
            return list; ;
        }
        public OutputModel Add(FoodMaterialTsfer foodsort)
        {
            if (foodsort == null)
            {
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            }
            if (service.Get(foodsort.Name) != null)
            {
                return OutputHelper.GetOutputResponse(ResultCode.DataExisted);
            }
            if (service.Add(foodsort))
            {
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            }
            else
            {
                return OutputHelper.GetOutputResponse(ResultCode.Error);
            }
        }
        public OutputModel Update(string id, string name)
        {
            int i;
            if (!int.TryParse(id, out i))
                return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
            FoodMaterialTsfer foodsort = service.Get(i);
            if (foodsort == null)
            {
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            }
            foodsort.Name = name;
            if (service.Update(foodsort))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
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

        public List<FoodMaterialTsfer> GetListByCookBookId(string cookBookId)
        {
            return  service.GetList(cookBookId);
        }
    }
}
