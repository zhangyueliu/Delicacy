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
        public FoodMaterialTsfer Get(string name)
        {
            return TransferObject.ConvertObjectByEntity<FoodMaterial, FoodMaterialTsfer>(base.Select(o => o.Name == name).FirstOrDefault());
        }
        public bool IsExist(int foodMaterialId)
        {
            return  Select(o => o.FoodMaterialId == foodMaterialId).Any();
        }
        public List<FoodMaterialTsfer> GetPage(int pageindex, int pagesize, out int rowcount)
        {
            List<FoodMaterial> list = SelectDesc(pageindex, pagesize, o => true, o => o.Priority, out rowcount).ToList();
            return TransferObject.ConvertObjectByEntity<FoodMaterial, FoodMaterialTsfer>(list);
        }
        public bool Add(FoodMaterialTsfer fsort)
        {
            base.Add(TransferObject.ConvertObjectByEntity<FoodMaterialTsfer, FoodMaterial>(fsort));
            return Save() > 0;
        }
        public bool Update(FoodMaterialTsfer fsort)
        {
            base.Update(TransferObject.ConvertObjectByEntity<FoodMaterialTsfer, FoodMaterial>(fsort));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
    }
}
