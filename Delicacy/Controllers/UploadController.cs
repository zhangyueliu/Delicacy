using System;
using Tool;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
namespace Delicacy.Controllers
{
    public class UploadController : BaseController
    {
        [HttpPost]
        public ContentResult UploadImg()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                return GetContentResult(UploadManager.UploadImg(files.Get("img")));
            }
            catch 
            {
                return GetContentResult(OutputHelper.GetOutputResponse(ResultCode.Error));
            }
        }
	}
}