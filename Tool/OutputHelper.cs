using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
   public class OutputHelper
    {
       public static OutputModel GetOutputResponse(ResultCode code, string message, object data)
       {
           return new OutputModel() { StatusCode = (int)code, Message = message, Data = data };
       }

       public static OutputModel GetOutputResponse(ResultCode code,  object data)
       {
           return GetOutputResponse( code ,EnumHelper.GetEnumDescription<ResultCode>(code),data);
       }

       public static OutputModel GetOutputResponse(ResultCode code, string message)
       {
           return GetOutputResponse(code, message, null);
       }

       public static OutputModel GetOutputResponse(ResultCode code)
       {
           return GetOutputResponse(code, EnumHelper.GetEnumDescription<ResultCode>(code),null);
       }
      
    }
}
