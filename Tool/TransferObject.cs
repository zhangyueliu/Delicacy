using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Tool
{
    public class TransferObject
    {
        public static List<To> ConvertObjectByEntity<T, To>(List<T> entitys)
        {
            Type type = typeof(To);
            List<To> list = new List<To>();
            if (entitys.Count == 0)
            {
                return list;
            }
            foreach (T entity in entitys)
            {
                To t = ConvertObjectByEntity<T, To>(entity);
                if (t != null)
                {
                    list.Add(t);
                }
            }

            return list;
        }

        public static To ConvertObjectByEntity<T, To>(T entity)
        {
            if (entity == null)
            {
                return default(To);
            }
            Type type = typeof(To);
            To t = CreateInstance<To>(type.Assembly.FullName, type.FullName);
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                PropertyInfo tpropertyInfo = propertyInfos.Where(o => o.Name == propertyInfo.Name).FirstOrDefault();
                if (tpropertyInfo == null)
                {
                    continue;
                }
                object value = GetPropertyValue(entity, tpropertyInfo.Name);
                if (value == null)
                {
                    continue;
                }
                propertyInfo.SetValue(t, value, null);

            }
            return t;
        }

        public static List<To> ConvertObjectByEntityIgnoreCase<T, To>(List<T> entitys)
        {
            Type type = typeof(To);
            List<To> list = new List<To>();
            if (entitys.Count == 0)
            {
                return list;
            }
            foreach (T entity in entitys)
            {
                To t = ConvertObjectByEntityIgnoreCase<T, To>(entity);
                if (t != null)
                {
                    list.Add(t);
                }
            }

            return list;
        }

        public static To ConvertObjectByEntityIgnoreCase<T, To>(T entity)
        {
            if (entity == null)
            {
                return default(To);
            }
            Type type = typeof(To);
            To t = CreateInstance<To>(type.Assembly.FullName, type.FullName);
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                PropertyInfo tpropertyInfo = propertyInfos.FirstOrDefault(o => string.Equals(o.Name, propertyInfo.Name, StringComparison.CurrentCultureIgnoreCase));
                if (tpropertyInfo == null)
                {
                    continue;
                }
                object value = GetPropertyValue(entity, tpropertyInfo.Name);
                if (value == null)
                {
                    continue;
                }
                propertyInfo.SetValue(t, value, null);

            }
            return t;
        }

        private static T CreateInstance<T>(string assemblyName, string fullName)
        {
            try
            {
                object ect = Assembly.Load(assemblyName).CreateInstance(fullName);
                return (T)ect;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        private static object GetPropertyValue(object entity, string propertyName)
        {
            PropertyInfo pi = entity.GetType().GetProperty(propertyName);

            if (pi == null)
            { return null; }

            return pi.GetValue(entity, null);
        }
    }
}

