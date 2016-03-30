using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class SupportScanRecordTsfer
    {
        public int SSRId { get; set; }
        public string  CookBookId { get; set; }
        public Nullable<int> UserId { get; set; }
        public int Type { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}
