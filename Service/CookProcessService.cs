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
    public class CookProcessService : BaseService<CookProcess>
    {
        public bool Add(CookProcessTsfer cookPro)
        {
            base.Add(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookPro));
            return Save() > 0;
        }
        public bool Update(CookProcessTsfer cookPro)
        {
            base.Update(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookPro));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public CookProcessTsfer Select(int id)
        {
            return TransferObject.ConvertObjectByEntity<CookProcess, CookProcessTsfer>(base.Select(id));
        }
    }
}
