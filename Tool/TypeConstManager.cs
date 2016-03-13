using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Collections.Concurrent;

namespace Tool
{
    public class TypeConstManager
    {
        private static ConcurrentDictionary<string, Dictionary<string, PropertyInfo>> typeProperties = new ConcurrentDictionary<string, Dictionary<string, PropertyInfo>>(StringComparer.OrdinalIgnoreCase);

        private static ConcurrentDictionary<string, Dictionary<string, string>> typeMap = new ConcurrentDictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
        public static Dictionary<string, PropertyInfo> GetPropertiesDictionary(Type type)
        {
            Dictionary<string, PropertyInfo> properties = null;
            if (!typeProperties.TryGetValue(type.FullName, out properties))
            {
                properties = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
                foreach (var p in type.GetProperties())
                {
                    properties.Add(p.Name, p);
                }
                typeProperties.TryAdd(type.FullName, properties);
            }
            return properties;
        }

        public static Dictionary<string, string> GetDefaultMap(Type type)
        {
            Dictionary<string, string> map = null;
            if (!typeMap.TryGetValue(type.FullName, out map))
            {
                map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (var property in GetPropertiesDictionary(type))
                {
                    map.Add(property.Key, property.Key);
                }
                typeMap.TryAdd(type.FullName, map);
            }
            return map;   
        }
    }
}
