using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DataTransfer
{
    public class CookBookTsfer
    {

        public string CookBookId { get; set; }
        [JsonIgnore]
        public int TasteId { get; set; }
        public string TasteName { get; set; }
        [JsonIgnore]
        public int FoodSortId { get; set; }
        public string FoodSortName { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Tips { get; set; }
        /// <summary>
        /// -1未通过 0待审核  1已通过 2存草稿   
        /// </summary>
        public int Status { get; set; }



        public System.DateTime DateTime { get; set; }

        public List<CookProcessTsfer> ListProcess { get; set; }
        public List<CookMaterialTsfer> ListMaterial { get; set; }


        public bool isCollection = false;

        /// <summary>
        /// 是否收藏 
        /// </summary>
        public bool IsCollection
        {
            get { return isCollection; }
            set { this.isCollection = value; }
        }

        /// <summary>
        /// 是否点赞
        /// </summary>
        public bool IsSupport { get; set; }


        /// <summary>
        /// 点赞数量
        /// </summary>
        public int SupportCount { get; set; }
    }
}

