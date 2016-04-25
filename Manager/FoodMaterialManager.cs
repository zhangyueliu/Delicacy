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
    }
}
