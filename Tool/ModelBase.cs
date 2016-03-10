using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;

namespace Tool
{


    #region 子类示例
    /*
     public class OperatorRights : Common.DB.ModelBase
    {
        public OperatorRights()
            : base("OperatorRights", new string[] { "OperatorID", "FCode" })
        {
        }

        #region 私有成员
        private Guid _OperatorID;
        private string _FCode;
        private string _FGCode;
        #endregion

        #region 数据属性
        public Guid OperatorID
        {
            get { return _OperatorID; }
            set
            {
                SetChangedProperty("OperatorID");
                _OperatorID = value;
            }
        }

        /// <summary>
        /// 操作代码
        /// </summary>
        public string FCode
        {
            get { return _FCode; }
            set
            {
                SetChangedProperty("FCode");
                _FCode = value;
            }
        }

        /// <summary>
        /// 模块代码
        /// </summary>
        public string FGCode
        {
            get { return _FGCode; }
            set
            {
                SetChangedProperty("FGCode");
                _FGCode = value;
            }
        }
        #endregion
    }
    */
    #endregion


    /// <summary>
    /// 实体类基类
    /// </summary>
    public abstract class ModelBase : ChangedBase
    {
        /// <summary>
        /// 表名
        /// </summary>
        private string tableName;

        private List<string[]> uniqueConstraints = new List<string[]>();

        /// <summary>
        /// 获取已设置了属性的第一个唯一约束，优先聚集索引
        /// </summary>
        /// <returns></returns>
        private string[] GetFirstUnique()
        {
            string[] result = null;
            foreach (var unique in uniqueConstraints)
            {
                bool flag = true;
                foreach (var k in unique)
                {
                    if (!IsChanged(k))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result = unique;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 修改部分map映射以处理属性跟数据库字段可能改的不一致的问题（历史原因不同命名规则）
        /// </summary>
        protected Dictionary<string, string> map;


        /// <summary>
        /// 基类构造函数
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="pk">主键,属性名，非字段名</param>
        /// <param name="uniqueConstraint">多个唯一约束,属性名，非字段名</param>
        protected ModelBase(string tbName, string[] pk, List<string[]> uniqueConstraint = null)
        {
            tableName = tbName;
            if (uniqueConstraint != null)
            {
                this.uniqueConstraints = uniqueConstraint;
            }
            this.uniqueConstraints.Insert(0, pk);
            map = TypeConstManager.GetDefaultMap(this.GetType());
        }


        /// <summary>
        /// SqlDataReader转化成List<>
        /// </summary>
        /// <typeparam name="T">转化成list的T</typeparam>
        /// <param name="sdr">传入的SqlDataReader必须ExecuteReader(CommandBehavior.CloseConnection)关闭Reader的同时会关闭Connection</param>
        /// <returns></returns>
        public List<T> ReaderToList<T>(SqlDataReader sdr) where T : ModelBase, new()
        {
            List<T> list = new List<T>();
            try
            {
                while (sdr.Read())
                {
                    var m = new T();
                    foreach (var p in properties)
                    {
                        var value = sdr[map[p.Key]];
                        if (value != DBNull.Value)
                        {
                            m.SetProperty(p.Key, value);
                        }
                    }
                    list.Add(m);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sdr.Dispose();
            }
            return list;
        }

        public string CreateGetSql(out List<SqlParameter> sqlparams, bool sqllock = false)
        {
            sqlparams = new List<SqlParameter>();
            StringBuilder sb = new StringBuilder();

            //主键按顺序，数据库中 也按顺序设置，严控 容易利用上索引
            foreach (var k in GetFirstUnique())
            {
                var value = GetProperty(k);
                if (value == null)
                {
                    sb.Append(string.Format("[{0}] is null,", map[k]));
                }
                else
                {
                    sb.Append(string.Format("[{0}]=@{1},", map[k], k));
                    sqlparams.Add(new SqlParameter("@" + k, value));
                }
            }
            var sql = "select * from [{0}] {2} where {1}";
            return string.Format(sql, tableName, sb.ToString().Trim(',').Replace(",", " and "), sqllock ? "" : "(nolock)");
        }

        public string CreateInsertSql(out List<SqlParameter> sqlparams)
        {
            sqlparams = new List<SqlParameter>();
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            foreach (var pName in ChangedProperties)
            {
                sb1.Append(string.Format("[{0}],", map[pName]));
                sb2.Append(string.Format("@{0},", pName));
                sqlparams.Add(new SqlParameter("@" + pName, GetProperty(pName)));
            }
            var sql = "insert into [{0}] ({1}) values ({2})";
            return string.Format(sql, tableName, sb1.ToString().Trim(','), sb2.ToString().Trim(','));
        }

        public string CreateUpdateSql(out List<SqlParameter> sqlparams)
        {
            sqlparams = new List<SqlParameter>();
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            var firstUnique = GetFirstUnique();
            foreach (var pName in ChangedProperties)
            {

                ///如果不是主键 才加到参数
                if (!firstUnique.Contains(pName))
                {
                    sb1.Append(string.Format("[{0}]=@{1},", map[pName], pName));
                    sqlparams.Add(new SqlParameter("@" + pName, GetProperty(pName)));
                }
            }
            //按主键生成条件，未设置主键的值的话，参数个对不对 会报错。
            //主键按顺序，数据库中 也按顺序设置，严控 容易利用上索引
            foreach (var k in firstUnique)
            {
                var value = GetProperty(k);
                if (value == null)
                {
                    sb2.Append(string.Format("[{0}] is null,", map[k]));
                }
                else
                {
                    sb2.Append(string.Format("[{0}]=@{1},", map[k], k));
                    sqlparams.Add(new SqlParameter("@" + k, value));
                }
            }
            var sql = "update [{0}] set {1} where {2}";
            return string.Format(sql, tableName, sb1.ToString().Trim(','), sb2.ToString().Trim(',').Replace(",", " and "));
        }

        /// <summary>
        /// 主键删除，实体主键赋值
        /// </summary>
        /// <param name="sqlparams">out 参数</param>
        /// <returns></returns>
        public string CreateDeleteSql(out List<SqlParameter> sqlparams)
        {
            sqlparams = new List<SqlParameter>();
            StringBuilder sb = new StringBuilder();

            //主键必须全部填加到条件里，防止忘记条件
            foreach (var k in GetFirstUnique())
            {
                var value = GetProperty(k);
                if (value == null)
                {
                    sb.Append(string.Format("[{0}] is null,", map[k]));
                }
                else
                {
                    sb.Append(string.Format("[{0}]=@{1},", map[k], k));
                    sqlparams.Add(new SqlParameter("@" + k, value));
                }
            }
            var sql = "delete from [{0}] where {1}";
            return string.Format(sql, tableName, sb.ToString().Trim(',').Replace(",", " and "));
        }


        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="sqlparams">out 参数</param>
        /// <param name="arrQuery">条件，不可空，防止误清空</param>
        /// <returns></returns>
        public string CreateDeleteSql(out List<SqlParameter> sqlparams, QueryBase query = null)
        {
            if (query == null)
            {
                throw new Exception("为防止误清空数据，删除操作必须有条件");
            }
            var strWhere = CreateWhereSql(out sqlparams, query);
            var sql = "delete from [{0}] {1}";
            return string.Format(sql, tableName, strWhere);
        }


        private int preQueryHashCode = 0;
        private int preQueryVersion = 0;
        private string preWhereSql = "";
        private List<SqlParameter> preWhereSqlParams = null;

        private string CreateWhereSql(out List<SqlParameter> sqlparams, QueryBase query = null)
        {
            if (query.GetHashCode() == preQueryHashCode && preQueryVersion == query.GetVersion())
            {
                sqlparams = preWhereSqlParams;
                return preWhereSql;
            }
            sqlparams = new List<SqlParameter>();
            var strWhere = "";
            List<QueryCondition> arrQuery = null;
            if (query != null) arrQuery = query.GetArrQuery();
            ///循环将条件里的属性参数与数据字段增加映射
            if (arrQuery == null) arrQuery = new List<QueryCondition>();
            foreach (var pName in ChangedProperties)
            {
                arrQuery.Add(new QueryCondition(LinkType.And, pName, CompareType.Equal, GetProperty(pName)));
            }

            if (arrQuery != null && arrQuery.Count > 0)
            {
                foreach (var q in arrQuery)
                {
                    q.Map = map;
                }
                strWhere = ConditionToSql.ToSqlText(arrQuery);
                sqlparams = ConditionToSql.ToSqlParas(arrQuery);
            }
            var strOtherWhere = query.GetOtherWhereSql(sqlparams);
            if (!string.IsNullOrWhiteSpace(strWhere) && !string.IsNullOrWhiteSpace(strOtherWhere))
            {
                strWhere += " and ";
            }
            else
            {
                strWhere += strOtherWhere;
            }
            if (!string.IsNullOrWhiteSpace(strWhere)) strWhere = "where " + strWhere;
            preQueryVersion = query.GetVersion();
            preQueryHashCode = query.GetHashCode();
            preWhereSql = strWhere;
            preWhereSqlParams = sqlparams;
            return strWhere;
        }

        /// <summary>
        /// 生成创建数目统计的sql
        /// </summary>
        /// <param name="sqlparams">输入sqlparams</param>
        /// <param name="arrQuery">条件</param>
        /// <returns></returns>
        public string CreateCountSql(out List<SqlParameter> sqlparams, QueryBase query = null, bool sqllock = false)
        {
            var strWhere = CreateWhereSql(out sqlparams, query);
            var sql = "select count(1) from [{0}] {2} {1}";
            return string.Format(sql, tableName, strWhere, sqllock ? "" : "(nolock)");
        }

        /// <summary>
        /// 生成创建select的sql语句
        /// </summary>
        /// <param name="sqlparams">输入sqlparams</param>
        /// <param name="arrSort">排序</param>
        /// <param name="start">第几条开始</param>
        /// <param name="size">读几条</param>
        /// <param name="arrQuery">查询条件,不传所有</param>
        /// <param name="columns">读哪几个字段</param>
        /// <returns></returns>
        public string CreateSelectSql(out List<SqlParameter> sqlparams, KeyValue<string, SortWay>[] arrSort = null, int? start = null, int? size = null, QueryBase query = null, string[] columns = null, bool sqllock = false)
        {
            StringBuilder sbSort = new StringBuilder();
            StringBuilder sbColumns = new StringBuilder();
            string strWhere = "";
            string strColumns = "*";
            if (columns != null && columns.Length > 0)
            {
                foreach (var c in columns)
                {
                    sbColumns.Append(",[");
                    sbColumns.Append(map[c]);
                    sbColumns.Append("]");

                }
                strColumns = sbColumns.ToString().TrimStart(',');
            }
            if (arrSort != null && arrSort.Length > 0)
            {
                arrSort = arrSort.Distinct().ToArray();
                foreach (var sort in arrSort)
                {
                    sbSort.Append("[");
                    sbSort.Append(map[sort.Key]);
                    sbSort.Append("]");
                    sbSort.Append(" ");
                    sbSort.Append(sort.Value.ToString());
                    sbSort.Append(",");
                }
            }
            strWhere = CreateWhereSql(out sqlparams, query);
            string sql;
            if (start.HasValue && size.HasValue)
            {
                sql = "select temp.* from (select {1},row_number() over (order by {3}) as _rows from [{0}] {6} {2}) temp where temp._rows between {4} and {5}";
                sql = string.Format(sql, tableName, strColumns, strWhere, sbSort.ToString().Trim(','), start.Value.ToString(), (start.Value + size.Value - 1).ToString(), sqllock ? "" : "(nolock)");


            }
            else if (size.HasValue)
            {
                sql = "select top {4} {1} from [{0}] {5} {2} order by {3}";
                sql = string.Format(sql, tableName, strColumns, strWhere, sbSort.ToString().Trim(','), size.Value.ToString(), sqllock ? "" : "(nolock)");
            }
            else
            {
                sql = "select {1} from [{0}] {4} {2} order by {3}";
                sql = string.Format(sql, tableName, strColumns, strWhere, sbSort.ToString().Trim(','), sqllock ? "" : "(nolock)");
            }
            return sql;
        }


        /// <summary>
        /// 返回tableName，用方法，不影响序列化
        /// </summary>
        /// <returns></returns>
        public string GetTableName()
        {
            return tableName;
        }
    }
}
