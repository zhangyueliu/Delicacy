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
    public class TasteService : BaseService<Taste>
    {
        public bool Add(TasteTsfer taste)
        {
            base.Add(TransferObject.ConvertObjectByEntity<TasteTsfer, Taste>(taste));
            return Save() > 0;
        }
        public bool Update(TasteTsfer taste)
        {
            base.Update(TransferObject.ConvertObjectByEntity<TasteTsfer ,Taste>(taste));
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public TasteTsfer Select(int id)
        {
            return TransferObject.ConvertObjectByEntity<Taste, TasteTsfer>(base.Select(id));
        }
    }
}
