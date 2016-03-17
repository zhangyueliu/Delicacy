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
        public Nullable<int> CookBookId { get; set; }
        public Nullable<int> UserId { get; set; }
        public int PId { get; set; }
        public string Content { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}
