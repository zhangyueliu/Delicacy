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
    public class SubjectSortService : BaseService<SubjectSort>
    {
        public bool Add(SubjectSortTsfer sort)
        {
            base.Add(TransferObject.ConvertObjectByEntity<SubjectSortTsfer, SubjectSort>(sort));
            return Save() > 0;
        }
        public bool Update(SubjectSortTsfer sort)
        {
            base.Update(TransferObject.ConvertObjectByEntity<SubjectSortTsfer, SubjectSort>(sort));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public SubjectSortTsfer Select(int id)
        {
            return TransferObject.ConvertObjectByEntity<SubjectSort, SubjectSortTsfer>(base.Select(id));
        }
    }
}
