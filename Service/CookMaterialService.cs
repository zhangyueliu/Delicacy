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
        public void AddNoSave(List<CookMaterialTsfer> list)
        {
            Add(TransferObject.ConvertObjectByEntity<CookMaterialTsfer, CookMaterial>(list));
        }
    }
}
