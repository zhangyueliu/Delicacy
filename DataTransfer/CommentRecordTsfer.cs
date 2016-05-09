using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataTransfer
{
    public  class CommentRecordTsfer
    {
        [Display(Name="id")]
        public int CommentId { get; set; }
        [Display(Name = "菜谱id或专题idid")]
        /// <summary>
        /// 实际操作id(菜谱id或专题id)
        /// </summary>
        public string OperateId { get; set; }
         [Display(Name = "用户")]
        public int UserId { get; set; }
         [Display(Name = "被评论实体名称")]
        public string OperateName { get; set; }
        /// <summary>
        /// 评论人的信息
        /// </summary>
        public UserInfoTsfer User { get; set; }
         [Display(Name = "评论父id")]
        public int PId { get; set; }
         [Display(Name = "显示id")]
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
