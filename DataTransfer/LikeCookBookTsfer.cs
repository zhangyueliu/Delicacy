using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class LikeCookBookTsfer
    {
        public int LikeId { get; set; }
        public string  CookBookId { get; set; }
        public int UserId { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}
