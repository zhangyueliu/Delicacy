using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
   public  class EnumHelper
    {
        /// <summary>
        /// 获取枚举值上的Description特性的说明
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="t">枚举值</param>
        /// <returns>特性的说明</returns>
        public static string GetEnumDescription<T>(T t)
        {
            var type = t.GetType();
            FieldInfo field = type.GetField(Enum.GetName(type, t));
            DescriptionAttribute descAttr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (descAttr == null)
            {
                return string.Empty;
            }

            return descAttr.Description;
        }
    }
}
