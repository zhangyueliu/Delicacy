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
        public SubjectSortTsfer Get(int id)
        {
            return TransferObject.ConvertObjectByEntity<SubjectSort, SubjectSortTsfer>(base.Select(id));
        }
        public SubjectSortTsfer Get(string name)
        {
            return TransferObject.ConvertObjectByEntity<SubjectSort, SubjectSortTsfer>(base.Select(o => o.Name == name).FirstOrDefault());
        }
        public List<SubjectSortTsfer> GetList()
        {
            return TransferObject.ConvertObjectByEntity<SubjectSort, SubjectSortTsfer>(base.Select(o => true).ToList());
        }
    }
}
