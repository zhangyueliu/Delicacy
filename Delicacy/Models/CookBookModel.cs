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

        /// <summary>
        /// 最终图片
        /// </summary>
        public string FinalImg { get; set; }
        /// <summary>
        /// 格式:  abc.jpg::过程描述|||def.jpg::过程描述
        /// </summary>
        public string ProcessImgDes { get; set; }

        /// <summary>
        ///0待审核  2存草稿
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 食材ID 格式  1::2::3  
        /// </summary>
        public string FoodMaterial { get; set; }
    }
}