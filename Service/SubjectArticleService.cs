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
   public  class SubjectArticleService:BaseService<SubjectArticle>
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
        public SubjectArticleTsfer Select(int id)
        {
            return TransferObject.ConvertObjectByEntity<SubjectArticle, SubjectArticleTsfer>(base.Select(id));
        }
    }
}
