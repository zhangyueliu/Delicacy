using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delicacy.Models
{
    public class CookBookModel
    {
        /// <summary>
        /// 口味
        /// </summary>
        public string Taste { get; set; }

        /// <summary>
        /// 菜谱类别
        /// </summary>
        public string FoodSort { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Tips { get; set; }
        


    }
}