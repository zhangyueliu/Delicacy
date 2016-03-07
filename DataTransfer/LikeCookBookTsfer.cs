using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class LikeCookBookTsfer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CookBookId { get; set; }
        public Nullable<int> Use_UserId { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}
