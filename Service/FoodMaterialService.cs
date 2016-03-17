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
        public bool Add(FoodMaterialTsfer fMaterial)
        {
            base.Add(TransferObject.ConvertObjectByEntity<FoodMaterialTsfer, FoodMaterial>(fMaterial));
            return Save() > 0;
        }
        public bool Update(FoodMaterialTsfer fMaterial)
        {
            base.Update(TransferObject.ConvertObjectByEntity<FoodMaterialTsfer, FoodMaterial>(fMaterial));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public FoodMaterialTsfer Get(string name)
        {
            return TransferObject.ConvertObjectByEntity<FoodMaterial, FoodMaterialTsfer>(base.Select(o => o.Name == name).FirstOrDefault());
        }
        public FoodMaterialTsfer Get(int id)
        {
            return TransferObject.ConvertObjectByEntity<FoodMaterial, FoodMaterialTsfer>(base.Select(id));
        }
        public List<FoodMaterialTsfer> GetList()
        {
            return TransferObject.ConvertObjectByEntity<FoodMaterial, FoodMaterialTsfer>(base.Select(o => true).ToList());
        }
    }
}
