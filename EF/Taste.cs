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
    
    public partial class Taste
    {
        public Taste()
        {
            this.CookBook = new HashSet<CookBook>();
        }
    
        public int TasteId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<CookBook> CookBook { get; set; }
    }
}
