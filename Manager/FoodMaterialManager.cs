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
        private FoodMaterialService Service = ObjectContainer.GetInstance<FoodMaterialService>();
        public OutputModel Add(FoodMaterialTsfer foodmaterial)
        {
            if (foodmaterial == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Get(foodmaterial.Name) != null)
                return OutputHelper.GetOutputResponse(ResultCode.DataExisted);
            if (Service.Add(foodmaterial))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Update(FoodMaterialTsfer foodmaterial)
        {
            if (foodmaterial == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Update(foodmaterial))
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
        public OutputModel Get(int id)
        {
           FoodMaterialTsfer f= Service.Get(id);
           if (f == null)
               return OutputHelper.GetOutputResponse(ResultCode.NoData);
           return OutputHelper.GetOutputResponse(ResultCode.OK, f);
        }
         public OutputModel Get(string name)
        {
            FoodMaterialTsfer f = Service.Get(name);
            if (f == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK,f);
        }
        public OutputModel GetList()
        {
           List<FoodMaterialTsfer>list= Service.GetList();
           if (list.Count == 0)
               return OutputHelper.GetOutputResponse(ResultCode.NoData);
           return OutputHelper.GetOutputResponse(ResultCode.OK,list);
        }
    }
}
