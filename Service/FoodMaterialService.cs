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
    public class FoodMaterialService : BaseService<FoodMaterial>
    {
        public List<FoodMaterialTsfer> GetList()
        {
            return TransferObject.ConvertObjectByEntity<FoodMaterial, FoodMaterialTsfer>(Select(o => true).OrderByDescending(o => o.Priority).ToList());
        }
        public FoodMaterialTsfer Get(int id)
        {
            return TransferObject.ConvertObjectByEntity<FoodMaterial, FoodMaterialTsfer>(Select(o => o.FoodMaterialId == id).FirstOrDefault());
        }
        public bool IsExist(int foodMaterialId)
        {
            return  Select(o => o.FoodMaterialId == foodMaterialId).Any();
        }
    }
}
