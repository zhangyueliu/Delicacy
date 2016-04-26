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
    public class FoodSortService : BaseService<FoodSort>
    {
       public bool Add(FoodSortTsfer fsort)
        {
            base.Add(TransferObject.ConvertObjectByEntity<FoodSortTsfer, FoodSort>(fsort));
            return Save() > 0;
        }
       public bool Update(FoodSortTsfer fsort)
        {
            base.Update(TransferObject.ConvertObjectByEntity<FoodSortTsfer, FoodSort>(fsort));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public FoodSortTsfer Get(int foodSortId)
        {
            return TransferObject.ConvertObjectByEntity<FoodSort, FoodSortTsfer>(base.Select(o => o.FoodSortId == foodSortId).FirstOrDefault());
        }
        public FoodSortTsfer Get(string name)
        {
            return TransferObject.ConvertObjectByEntity<FoodSort, FoodSortTsfer>(base.Select(o => o.Name == name).FirstOrDefault());
        }
        public List<FoodSortTsfer> GetList()
        {
            return TransferObject.ConvertObjectByEntity<FoodSort, FoodSortTsfer>(base.Select(o => true).OrderByDescending(o=>o.FoodSortId).ToList());
        }
        public List<FoodSortTsfer> GetPage(int pageindex,int pagesize,out int rowcount)
        {
            List<FoodSort> list = SelectDesc(pageindex, pagesize, o => true, o => o.FoodSortId, out rowcount).ToList();
            return TransferObject.ConvertObjectByEntity<FoodSort, FoodSortTsfer>(list);
        }

        public bool IsExist(int foodSortId)
        {
            return base.Select(o => o.FoodSortId == foodSortId).Any();
        }
    }
}
