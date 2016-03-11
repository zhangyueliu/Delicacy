using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Reflection;

namespace Tool
{
    public static class ObjectContainer
    {
        public static T GetInstance<T>() where T:class
        {
            Type type = typeof(T);
            string className = type.FullName;
            if (CallContext.GetData(className) == null)
                CallContext.SetData(className, Activator.CreateInstance<T>());
            return CallContext.GetData(className)  as T;
        }
    }
}
