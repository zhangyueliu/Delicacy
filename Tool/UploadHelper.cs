using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace Tool
{
    public static class UploadHelper
    {
        public static bool UploadImg(HttpPostedFileBase img,out string newImgName ,string savePath = "~/Upload/Images/")
        {
            newImgName = "";
            if (img == null || img.ContentLength == 0)
                return false;
            string extension = Path.GetExtension(img.FileName);
            if (!RegExVerify.CheckImgExtension(extension))
                return false;
            newImgName = Guid.NewGuid().ToString().Replace("-", "") + extension;
            string path = System.Web.HttpContext.Current.Server.MapPath(savePath);
            try
            {
                img.SaveAs(path + newImgName);
                newImgName = "/Upload/Images/" + newImgName;
            }
            catch 
            {
                return false;
            }
            
            return true;
        }
    }
}
