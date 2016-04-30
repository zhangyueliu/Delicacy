using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class TasteTsfer
    {
        public int TasteId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 1系统添加 0用户添加
        /// </summary>
        public short Status { get; set; }
    }
}
