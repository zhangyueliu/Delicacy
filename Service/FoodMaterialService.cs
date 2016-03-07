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
        public bool Add(FoodMaterialTsfer fMaterail)
        {
            base.Add(TransferObject.ConvertObjectByEntity<FoodMaterialTsfer, FoodMaterial>(fMaterail));
            return Save() > 0;
        }
        public bool Update(FoodMaterialTsfer fMaterail)
        {
            base.Update(TransferObject.ConvertObjectByEntity<FoodMaterialTsfer, FoodMaterial>(fMaterail));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public FoodMaterialTsfer Select(int id)
        {
            return TransferObject.ConvertObjectByEntity<FoodMaterial, FoodMaterialTsfer>(base.Select(id));
        }
    }
}
