using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;
using System.Web;
using System.IO;

namespace Manager
{
public  static   class UploadManager
    {
    public static object UploadImg(HttpPostedFileBase img)
    {
        string newImgName;
        if(UploadHelper.UploadImg(img, out newImgName))
            return  new { code = 200, successFileLength = 1 ,url=newImgName};
        else
            return new { code = -1, successFileLength = 1 };
        //return UploadHelper.UploadImg(img);
    }
    }
}
