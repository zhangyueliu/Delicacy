using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using DataTransfer;
using Tool;

namespace Service
{
    public class FoodMaterial_CookBookTsferService : BaseService<FoodMaterial_CookBook>
    {
        public List<FoodMaterial_CookBookTsfer> GetListByFoodMaterialId(int foodMaterialId)
        {
            return TransferObject.ConvertObjectByEntity<FoodMaterial_CookBook, FoodMaterial_CookBookTsfer>(Select(o => o.FoodMaterialId == foodMaterialId).ToList());
        }

        public IQueryable<string> GetIQueryCookBookId(int foodMaterialId)
        {
            return Select(o => o.FoodMaterialId == foodMaterialId).Select(o => o.CookBookId);
        }
    }
}
