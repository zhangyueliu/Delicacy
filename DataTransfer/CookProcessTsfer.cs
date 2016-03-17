using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class CookProcessTsfer
    {
        public int CookProcessId { get; set; }
        public Nullable<int> CookBookId { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
    }
}
