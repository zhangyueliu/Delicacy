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
    public static OutputModel UploadImg(HttpPostedFileBase img)
    {
        return UploadHelper.UploadImg(img);
    }
    }
}
