using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class SubjectArticleTsfer
    {
        public int SubjectArticleId { get; set; }
        public int SubjectSortId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Content { get; set; }
        public System.DateTime Datetime { get; set; }
    }
}
