using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Dynamic;
using System.Collections;
using System.Collections.ObjectModel;

namespace Tool
{
    public class DynamicJsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null) throw new ArgumentNullException("dictionary");
            if (type == typeof(object)) { return new DynamicJsonObject(dictionary); }

            return null;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(object) })); }
        }
    }

    public class DynamicJsonObject : DynamicObject
    {
        private IDictionary<string, object> Dictionary { get; set; }

        public DynamicJsonObject(IDictionary<string, object> dictionary)
        {
            this.Dictionary = dictionary;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this.Dictionary[binder.Name];

            if (result is IDictionary<string, object>) { result = new DynamicJsonObject(result as IDictionary<string, object>); }
            else if (result is ArrayList && (result as ArrayList) is IDictionary<string, object>)
            {
                result = new List<DynamicJsonObject>((result as ArrayList).ToArray().Select(x => new DynamicJsonObject(x as IDictionary<string, object>)));
            }
            else if (result is ArrayList)
            {
                result = new List<object>((result as ArrayList).ToArray());
            }

            return this.Dictionary.ContainsKey(binder.Name);
        }
    }

    public class Json
    {
       
        /// <summary>
        /// 序列化为JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize<T>(T t, bool format = false)
        {
            var jsonSerializer = new JavaScriptSerializer();
            if (format) return Format(jsonSerializer.Serialize(t));
            return jsonSerializer.Serialize(t);
        }

        /// <summary>
        /// 反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string s)
        {
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Deserialize<T>(s);
        }

        public static dynamic Deserialize(string jsonStr)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });

            dynamic glossaryEntry = jss.Deserialize(jsonStr, typeof(object)) as dynamic;
            return glossaryEntry;
        }
        private static string b(string c, int d)
        {
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < d; i++)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }


        public static string Format(string g)
        {
            //g=System.Text.RegularExpressions.Regex.Replace(g, ",\\\"([^,\\\"]*)?\\\":null,", ",");
            //g = System.Text.RegularExpressions.Regex.Replace(g, ",?\\\"([^,\\\"]*)?\\\":null,?", "");
            int f = 0;
            int e = 0;
            string h = "    ";
            StringBuilder d = new StringBuilder();
            int j = 0;
            bool k = false;
            char c;
            char[] chars = g.ToCharArray();
            for (f = 0, e = chars.Length; f < e; f += 1)
            {
                c = chars[f];
                switch (c)
                {
                    case '{':
                    case '[':
                        if (!k)
                        {
                            d.Append(c + "\r\n" + b(h, j + 1));
                            j += 1;
                        }
                        else
                        {
                            d.Append(c);
                        }
                        break;
                    case '}':
                    case ']':
                        if (!k)
                        {
                            j -= 1;
                            d.Append("\r\n" + b(h, j) + c);
                        }
                        else
                        {
                            d.Append(c);
                        }
                        break;
                    case ',':
                        if (!k)
                        {
                            d.Append(",\r\n" + b(h, j));
                        }
                        else
                        {
                            d.Append(c);
                        }
                        break;
                    case ':':
                        if (!k)
                        {
                            d.Append(": ");
                        }
                        else
                        {
                            d.Append(c);
                        }
                        break;
                    case ' ':
                    case '\n':
                    case '\t':
                        if (k)
                        {
                            d.Append(c);
                        }
                        break;
                    case '"':
                        if (f > 0 && chars[f - 1] != '\\')
                        {
                            k = !k;
                        }
                        d.Append(c);
                        break;
                    default:
                        d.Append(c);
                        break;
                }
            }
            return d.ToString();
            //1个,换成2个 然后,,$1,, $1中不含有:号的 是字符串中的, 把\n\s去掉
            //return d.replace(/,/g, ",,").replace(/,\n\s+([^:,]+),/g, ",$1,").replace(/,,/g, ",");
        }
    }
}
