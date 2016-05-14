using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    /// <summary>
    /// 收藏表
    /// </summary>
    public class CollectionTsfer
    {
        public int CollectionId { get; set; }
        public string OperateId { get; set; }
        public int UserId { get; set; }
        public System.DateTime DateTime { get; set; }
        public short Type { get; set; }
    }
}
