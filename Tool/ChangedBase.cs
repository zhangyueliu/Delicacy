using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Tool
{
    public abstract class ChangedBase
    {

        private int version=0;
        public int GetVersion()
        {
            return version;
        }

        /// <summary>
        /// 修改过的属性，并且按顺序，顺序很重要，将作为生成where语句等等顺序的依据
        /// </summary>
        protected HashSet<string> ChangedProperties = new HashSet<string>();

        /// <summary>
        /// 判断是否设置改变了
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        public bool IsChanged(string propertyName)
        {
            return ChangedProperties.Contains(propertyName);
        }

        /// <summary>
        /// 返回修改了几个属性,方法不会影响序列化
        /// </summary>
        public int GetChangedCount()
        {
            return ChangedProperties.Count;
        }

        /// <summary>
        /// 缓存子类的property信息数组
        /// </summary>
        protected Dictionary<string, PropertyInfo> properties;


        public ChangedBase()
        {
            properties = TypeConstManager.GetPropertiesDictionary(this.GetType());
        }

        /// <summary>
        /// 供子类的属性Set方法调用，监控哪个属性设置了
        /// </summary>
        /// <param name="properyName"></param>
        protected void SetChangedProperty(string propertyName)
        {
            version++;
            if (properties.ContainsKey(propertyName))
                if (!ChangedProperties.Contains(propertyName)) ChangedProperties.Add(propertyName);
        }


        /// <summary>
        /// 动态设置属性
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="value">值</param>
        public bool SetProperty(string propertyName, object value)
        {
            if (properties.ContainsKey(propertyName))
            {
                try
                {
                    properties[propertyName].SetValue(this, value, null);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 动态获取属性
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="propertyName">属性名称</param>
        /// <returns>返回值</returns>
        public T GetProperty<T>(string propertyName)
        {
            return (T)GetProperty(propertyName);
        }

        /// <summary>
        /// 动态获取属性
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>返回值</returns>
        public object GetProperty(string propertyName)
        {
            if (properties.ContainsKey(propertyName))
            {
                return properties[propertyName].GetValue(this,null);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 按照设置了哪些属性，并且按设置顺序，转化为字典保证顺序的存在
        /// </summary>
        /// <returns>返回字典</returns>
        public ListDictionary ToDictionary()
        {
            ListDictionary listDic = new ListDictionary();
            foreach (var pName in ChangedProperties)
            {
                var val = GetProperty(pName);
                if (val is DateTime)
                {
                    listDic.Add(pName, ((DateTime)val).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else if (val is ChangedBase)
                {
                    listDic.Add(pName, ((ChangedBase)val).ToDictionary());
                }
                else if (val is ChangedBase[])
                {
                    List<ListDictionary> listChangedBase = new List<ListDictionary>();
                    foreach (var v in (ChangedBase[])val)
                    {
                        listChangedBase.Add(v.ToDictionary());
                    }
                    listDic.Add(pName, listChangedBase);

                }
                else if (val != null && val.GetType().GetInterface("ICollection", true) != null)
                {
                    List<ListDictionary> listChangedBase = new List<ListDictionary>();
                    foreach (var v in (System.Collections.ICollection)val)
                    {
                        if (v is ChangedBase)
                        {
                            listChangedBase.Add(((ChangedBase)v).ToDictionary());
                        }
                        else { break; }
                    }
                    if (listChangedBase.Count > 0)
                    {
                        listDic.Add(pName, listChangedBase);
                    }
                    else
                    {
                        listDic.Add(pName, val);
                    }
                }
                else
                {
                    listDic.Add(pName, val);
                }
            }
            return listDic;
        }

        /// <summary>
        /// 按照设置了哪些属性，并且按设置顺序，序列化，保证顺序的存在
        /// </summary>
        /// <returns>返回序列化后的字符串</returns>
        public string ToJSONSerialize()
        {
            var json = Json.Serialize(ToDictionary());
            return json;
        }

        /// <summary>
        /// 复制到同样继承了ChangedBase的类的实例
        /// </summary>
        /// <typeparam name="T">同样继承了ChangedBase的类的实例的类型</typeparam>
        ///  <param name="m">同样继承了ChangedBase的类的实例</param>
        /// <returns>返回T的实例m</returns>
        public T CopyTo<T>(T m) where T : ChangedBase, new()
        {
            foreach (var pName in ChangedProperties)
            {
                m.SetProperty(pName, this.GetProperty(pName));
            }
            return m;
        }

        /// <summary>
        /// 复制一个同样继承了ChangedBase的类的实例
        /// </summary>
        /// <typeparam name="T">同样继承了ChangedBase的类的实例的类型</typeparam>
        /// <returns>new 一个T的实例</returns>
        public T Copy<T>() where T : ChangedBase, new()
        {
            var m = new T();
            return CopyTo<T>(m);
        }
    }
}
