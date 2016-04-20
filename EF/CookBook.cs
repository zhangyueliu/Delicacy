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
    
    public partial class CookBook
    {
        public CookBook()
        {
            this.CommentRecord = new HashSet<CommentRecord>();
            this.CookMaterial = new HashSet<CookMaterial>();
            this.CookProcess = new HashSet<CookProcess>();
            this.LikeCookBook = new HashSet<LikeCookBook>();
            this.SupportScanRecord = new HashSet<SupportScanRecord>();
        }
    
        public string CookBookId { get; set; }
        public Nullable<int> TasteId { get; set; }
        public Nullable<int> FoodSortId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Tips { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    
        public virtual ICollection<CommentRecord> CommentRecord { get; set; }
        public virtual FoodSort FoodSort { get; set; }
        public virtual Taste Taste { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual ICollection<CookMaterial> CookMaterial { get; set; }
        public virtual ICollection<CookProcess> CookProcess { get; set; }
        public virtual ICollection<LikeCookBook> LikeCookBook { get; set; }
        public virtual ICollection<SupportScanRecord> SupportScanRecord { get; set; }
    }
}
