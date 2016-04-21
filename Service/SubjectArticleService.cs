using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using DataTransfer;
using Tool;

namespace Service
{
    public class SubjectArticleService : BaseService<SubjectArticle>
    {
        public bool Add(SubjectArticleTsfer sa)
        {
            base.Add(TransferObject.ConvertObjectByEntity<SubjectArticleTsfer, SubjectArticle>(sa));
            return Save() > 0;
        }
        public bool Update(SubjectArticleTsfer sort)
        {
            base.Update(TransferObject.ConvertObjectByEntity<SubjectArticleTsfer, SubjectArticle>(sort));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }

        /// <summary>
        /// 删除专题列表
        /// </summary>
        /// <param name="sortid"></param>
        /// <returns></returns>
        public bool DeleteList(List<SubjectArticleTsfer> list)
        {
            base.Delete(TransferObject.ConvertObjectByEntity<SubjectArticleTsfer, SubjectArticle>(list));
            return Save() > 0;
        }
        public SubjectArticleTsfer Get(int id)
        {
            return TransferObject.ConvertObjectByEntity<SubjectArticle, SubjectArticleTsfer>(base.Select(id));
        }
        ///// <summary>
        ///// 获取某用户下的专题
        ///// </summary>
        ///// <param name="userid"></param>
        ///// <returns></returns>
        //public List<SubjectArticleTsfer> GetUsers(int userid)
        //{
        //    return TransferObject.ConvertObjectByEntity<SubjectArticle, SubjectArticleTsfer>(base.Select(o => o.UserId == userid).ToList());
        //}
        /// <summary>
        /// 获取分类下的饮食专题
        /// </summary>
        /// <param name="subjectsortid">分类id</param>
        /// <returns></returns>
        public List<SubjectArticleTsfer> GetSubSort(int subjectsortid)
        {
            return TransferObject.ConvertObjectByEntity<SubjectArticle, SubjectArticleTsfer>(base.Select(o => o.SubjectSortId == subjectsortid).ToList());
        }
        public List<SubjectArticleTsfer> GetList()
        {
            return TransferObject.ConvertObjectByEntity<SubjectArticle, SubjectArticleTsfer>(base.Select(o => true).ToList());
        }
    }
}

