using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace DataTransfer
{
    public  class CookBookTsfer
    {

        public string CookBookId { get; set; }
        public int TasteId { get; set; }
        [Display(Name = "口味")]
        public string TasteName { get; set; }
        public int FoodSortId { get; set; }
        [Display(Name = "分类")]
        public string FoodSortName { get; set; }
        public int UserId { get; set; }
        [Display(Name = "用户")]
        public string UserName { get; set; }
        [Display(Name = "菜谱名称")]
        public string Name { get; set; }
        [Display(Name = "成品图")]
        public string ImgUrl { get; set; }
        [Display(Name = "描述")]
        public string Description { get; set; }
        [Display(Name = "小窍门")]
        public string Tips { get; set; }
        [Display(Name = "审核状态")]
        /// <summary>
        /// -1未通过 0待审核  1已通过   
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

