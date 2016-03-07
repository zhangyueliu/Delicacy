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
   public class LikeCookBookService:BaseService<LikeCookBook>
    {
       public bool Add(LikeCookBookTsfer like)
        {
            base.Add(TransferObject.ConvertObjectByEntity<LikeCookBookTsfer, LikeCookBook>(like));
            return Save() > 0;
        }
       public bool Update(LikeCookBookTsfer like)
        {
            base.Update(TransferObject.ConvertObjectByEntity<LikeCookBookTsfer, LikeCookBook>(like));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public LikeCookBookTsfer Select(int id)
        {
            return TransferObject.ConvertObjectByEntity<LikeCookBook, LikeCookBookTsfer>(base.Select(id));
        }
    }
}
