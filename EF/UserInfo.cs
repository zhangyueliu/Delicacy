//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.CommentRecord = new HashSet<CommentRecord>();
            this.CookBook = new HashSet<CookBook>();
            this.LikeCookBook = new HashSet<LikeCookBook>();
            this.SubjectArticle = new HashSet<SubjectArticle>();
            this.SupportScanRecord = new HashSet<SupportScanRecord>();
            this.VerifyRegister = new HashSet<VerifyRegister>();
        }
    
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public short Status { get; set; }
        public System.DateTime RegisterDate { get; set; }
    
        public virtual ICollection<CommentRecord> CommentRecord { get; set; }
        public virtual ICollection<CookBook> CookBook { get; set; }
        public virtual ICollection<LikeCookBook> LikeCookBook { get; set; }
        public virtual ICollection<SubjectArticle> SubjectArticle { get; set; }
        public virtual ICollection<SupportScanRecord> SupportScanRecord { get; set; }
        public virtual ICollection<VerifyRegister> VerifyRegister { get; set; }
    }
}
