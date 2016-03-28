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
    public class VerifyRegisterServer : BaseService<VerifyRegister>
    {
        public VerifyRegisterTsfer Get(string guid)
        {
            return TransferObject.ConvertObjectByEntity<VerifyRegister, VerifyRegisterTsfer>(Select(o => o.GUID == guid).FirstOrDefault());
        }

        public bool Update(VerifyRegisterTsfer verifyDt)
        {
            base.Update(TransferObject.ConvertObjectByEntity<VerifyRegisterTsfer, VerifyRegister>(verifyDt));
            return Save() > 0;
        }
    }
}
