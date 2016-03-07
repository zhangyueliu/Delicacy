using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public  class CookBookTsfer
    {
        public int CookBookId { get; set; }
        public Nullable<int> TasteId { get; set; }
        public Nullable<int> FoodSortId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Tips { get; set; }
        public int Status { get; set; }
    }
}
