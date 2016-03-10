using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tool
{
    public enum RangeType
    {
        /// <summary>
        /// 中间
        /// </summary>
        Middle = 0,

        /// <summary>
        /// 两侧
        /// </summary>
        Side = 1
    }
    public class QueryRange<T> : ChangedBase
    {
        private RangeType _Type;
        private T _Max;
        private T _Min;

        public RangeType Type
        {
            get { return _Type; }
            set
            {
                SetChangedProperty("Type");
                _Type = value;
            }
        }
        public T Max
        {
            get { return _Max; }
            set
            {
                SetChangedProperty("Max");
                _Max = value;
            }
        }
        public T Min
        {
            get { return _Min; }
            set
            {
                SetChangedProperty("Min");
                _Min = value;
            }
        }
    }

    public abstract class QueryBase : ChangedBase
    {
        private string[] arrIgnoreAutoQuery;


        /// <summary>
        /// 设置自动忽略的条件
        /// </summary>
        /// <param name="ignoreAutoQuery">忽略自动条件，个性化搜索实体的时候用</param>
        public QueryBase(string[] ignoreAutoQuery=null)
        {
            arrIgnoreAutoQuery = ignoreAutoQuery;
        }

        public bool IsGetSimple { get; set; }

        public virtual string[] GetSimpleProperties()
        {
            if (IsGetSimple)
            {
                throw new Exception("设置了获取简单数据模式，则必须重写GetSimpleProperties方法");
            }
            else
            {
                return null;
            }
        }

        private void AddQueryCondition(List<QueryCondition> list,string pName)
        {
            //忽略自动条件的跳过
            var val = GetProperty(pName);
            if (val == null)
            {
                list.Add(new QueryCondition(LinkType.And, pName, CompareType.IsNull, DBNull.Value));
            }
            else if (val.ToString().Contains("%"))
            {
                list.Add(new QueryCondition(LinkType.And, pName, CompareType.Like, val));
            }
            else if (val is Array || val.GetType().GetInterface("ICollection", true) != null)
            {
                list.Add(new QueryCondition(LinkType.And, pName, CompareType.In, val));
            }
            else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(QueryRange<>))
            {
                var valRange = (ChangedBase)val;
                var rangeList = new List<QueryCondition>();
                switch ((RangeType)valRange.GetProperty("Type"))
                {
                    case RangeType.Middle:
                        if (valRange.IsChanged("Max")) rangeList.Add(new QueryCondition(LinkType.And, pName, CompareType.LET, valRange.GetProperty("Max")));
                        if (valRange.IsChanged("Min")) rangeList.Add(new QueryCondition(LinkType.And, pName, CompareType.GET, valRange.GetProperty("Min")));
                        break;
                    case RangeType.Side:
                        if (valRange.IsChanged("Max")) rangeList.Add(new QueryCondition(LinkType.Or, pName, CompareType.GET, valRange.GetProperty("Max")));
                        if (valRange.IsChanged("Min")) rangeList.Add(new QueryCondition(LinkType.Or, pName, CompareType.LET, valRange.GetProperty("Min")));
                        break;
                }
                list.Add(new QueryCondition(LinkType.And, rangeList));
            }
            else
            {
                list.Add(new QueryCondition(LinkType.And, pName, CompareType.Equal, val));
            }
        }

        public List<QueryCondition> GetArrQuery()
        {
            List<QueryCondition> list = new List<QueryCondition>();
            foreach (var pName in ChangedProperties)
            {
                if (arrIgnoreAutoQuery != null && arrIgnoreAutoQuery.Contains(pName)) continue;
                AddQueryCondition(list, pName);
            }
            return list;
        }


        /// <summary>
        /// 基类中不实现此方法，子类中如果需要，必须重写修饰符覆盖掉
        /// </summary>
        /// <param name="Sqlparams"></param>
        /// <returns></returns>
        public virtual string GetOtherWhereSql(IList<System.Data.SqlClient.SqlParameter> sqlparams)
        {
            return string.Empty;
        }
    }
}
