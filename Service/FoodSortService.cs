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
        public FoodSortTsfer GetFoodSort(int foodSortId)
        {
            return TransferObject.ConvertObjectByEntity<FoodSort, FoodSortTsfer>(base.Select(o => o.FoodSortId == foodSortId).FirstOrDefault());
        }

        public bool IsExist(int foodSortId)
        {
            return base.Select(o => o.FoodSortId == foodSortId).Any();
        }
    }
}
