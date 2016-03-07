using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace EF
{
    public static  class EFDataAccess
    {
        public static DbContext CreateContext()
        {
            if (CallContext.GetData("context") != null)
                CallContext.SetData("context", new DbContext("DelicacyEntities"));
            return CallContext.GetData("context") as DbContext;
        }
    }
}
