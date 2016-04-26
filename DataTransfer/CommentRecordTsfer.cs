using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public  class CommentRecordTsfer
    {
        public int CommentId { get; set; }
        /// <summary>
        /// 实际操作id(菜谱id或专题id)
        /// </summary>
        public string OperateId { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// 评论人的信息
        /// </summary>
        public UserInfoTsfer User { get; set; }
        public int PId { get; set; }
        /// <summary>
        /// 评论的根ID
        /// </summary>
        public int RootId { get; set; }
        public string Content { get; set; }
        public System.DateTime DateTime { get; set; }
        /// <summary>
        /// 1菜谱评论  2专题评论
        /// </summary>
        public short Type { get; set; }

        private List<CommentRecordTsfer> sonComment = new List<CommentRecordTsfer>();
        /// <summary>
        /// 当前评论下的子评论
        /// </summary>
        public List<CommentRecordTsfer> SonComment { get { return sonComment; } set { this.sonComment = value; } }
    }
}
