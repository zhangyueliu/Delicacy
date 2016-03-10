using System;
using System.Collections.Generic;
namespace Tool
{
    public class QueryCondition
    {

        public QueryCondition(LinkType linkType, List<QueryCondition> subQuery)
        {
            LinkType = linkType;
            SubQuery = subQuery.ToArray();
        }
        public QueryCondition(LinkType linkType, string paramsName, CompareType compareType, object value, List<QueryCondition> subQuery=null)
        {
            LinkType = linkType;
            ParamsName = paramsName;
            CompareType = compareType;
            Value = value;
            if (subQuery != null) SubQuery = subQuery.ToArray();
        }

        public LinkType LinkType
        {
            get;
            set;
        }

        /// <summary>
        /// 属性名与字段名映射关系
        /// </summary>
        public Dictionary<string, string> Map { get; set; }
 
        /// <summary>
        /// 参数名@ 一般对应实体属性
        /// </summary>
        public string ParamsName
        {
            get;
            set;
        }


        /// <summary>
        /// 列名,如果映射关系不在，直接返回参数名
        /// </summary>
        public string ColumnsName
        {
            get { return Map == null ? ParamsName : Map[ParamsName]; }
        }


        public CompareType CompareType
        {
            get;
            set;
        }

        
       
        public object Value
        {
            get;
            set;
        }

        public QueryCondition[] SubQuery
        {
            get;
            set;
        }

        public new string ToString()
        {
            if (this.ColumnsName == null && (this.SubQuery == null || this.SubQuery.Length <= 0))
            {
                return string.Empty;
            }

            string text = string.Empty;
            if (this.SubQuery != null && this.SubQuery.Length > 0)
            {
                QueryCondition[] subQuery = this.SubQuery;
                for (int i = 0; i < subQuery.Length; i++)
                {
                    QueryCondition queryCondition = subQuery[i];
                    text = text + "," + queryCondition.ToString();
                }
                if (!string.IsNullOrEmpty(text))
                {
                    text = text.Substring(1);
                }
            }

            return "{" + string.Format("LinkType:{0},ColumnsName:{1},ParamsName:{2},CompareType:{3},Value:{4},SubQuery:[{5}]", new object[]
			{
				this.LinkType.ToString(),
				this.ColumnsName ?? string.Empty,
                this.ParamsName ?? string.Empty,
				this.CompareType.ToString(),
				this.Value ?? string.Empty,
				text
			}) + "}";
        }
    }
}
