using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransfer;
using Tool;
using Service;

namespace Manager
{
   public class FoodMaterial_CookBookTsferManager
    {
       private FoodMaterial_CookBookTsferService service = ObjectContainer.GetInstance<FoodMaterial_CookBookTsferService>();
       public List<FoodMaterial_CookBookTsfer> GetListByFoodMaterialId(int id)
       {
           List<FoodMaterial_CookBookTsfer> list = service.GetListByFoodMaterialId(id);
           return list;
       }
    }
}
