using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
   public  class OutputModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public DateTime CurrentTime { get { return DateTime.Now; } }
        public object Data { get; set; }
    }
}
