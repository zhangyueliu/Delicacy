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
    public class CommentRecordService : BaseService<CommentRecord>
    {
        public bool Add(CommentRecordTsfer comment)
        {
            base.Add(TransferObject.ConvertObjectByEntity<CommentRecordTsfer, CommentRecord>(comment));
            return Save() > 0;
        }
        public bool Update(CommentRecordTsfer comment)
        {
            base.Update(TransferObject.ConvertObjectByEntity<CommentRecordTsfer, CommentRecord>(comment));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public CommentRecordTsfer Select(int id)
        {
            return TransferObject.ConvertObjectByEntity<CommentRecord,CommentRecordTsfer>(base.Select(id));
        }
    }
}
