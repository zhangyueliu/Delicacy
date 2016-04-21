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
    public class CookMaterialService : BaseService<CookMaterial>
    {
        public List<CookMaterialTsfer> GetList(string cookBookId)
        {
            return TransferObject.ConvertObjectByEntity<CookMaterial, CookMaterialTsfer>(Select(o => o.CookBookId == cookBookId).ToList());
        }
    }
}
