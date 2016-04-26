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
        public new bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public CommentRecordTsfer Get(int id)
        {
            return TransferObject.ConvertObjectByEntity<CommentRecord,CommentRecordTsfer>(base.Select(id));
        }
        /// <summary>
        /// 获取子评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CommentRecordTsfer> Gets(int id)
        {
            return TransferObject.ConvertObjectByEntity<CommentRecord, CommentRecordTsfer>(base.Select(o => o.PId == id).ToList());
        }
        /// <summary>
        /// 获取某菜谱的评论
        /// </summary>
        /// <param name="cookbookid"></param>
        /// <returns></returns>
        public List<CommentRecordTsfer> GetListCookBook(string  cookbookid)
        {
            return TransferObject.ConvertObjectByEntity<CommentRecord, CommentRecordTsfer>(base.Select(o => o.OperateId == cookbookid&&o.Type==1).ToList());
        }
        /// <summary>
        /// 获取某用户的所有评论
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<CommentRecordTsfer> GetListUser(int userid)
        {
            return TransferObject.ConvertObjectByEntity<CommentRecord, CommentRecordTsfer>(base.Select(o => o.UserId == userid).ToList());
        }

        public bool IsExist(int commentId)
        {
            return Select(o => o.CommentId == commentId).Any();
        }
    }
}
