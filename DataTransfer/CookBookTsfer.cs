using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public  class CookBookTsfer
    {

        public string CookBookId { get; set; }
        public Nullable<int> TasteId { get; set; }
        public Nullable<int> FoodSortId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Tips { get; set; }
        /// <summary>
        /// -1未通过 0待审核  1已通过 2存草稿   
        /// </summary>
        public int Status { get; set; }

        

        public Nullable<System.DateTime> DateTime { get; set; }

        public List<CookProcessTsfer> ListProcess { get; set; }
    }
}
