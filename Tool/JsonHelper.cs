using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Tool
{
    public static class JsonHelper
    {
        public static string SerializeObject(object data)
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            //这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式     
            timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
            return  JsonConvert.SerializeObject(data, Formatting.Indented, timeConverter);
        }

        public static object  UnserializeString(string jsonStr)
        {
           return   JsonConvert.DeserializeObject(jsonStr);
        }
    }
}
