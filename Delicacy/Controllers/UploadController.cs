using System;
using Tool;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager;
using Newtonsoft.Json;

namespace Delicacy.Controllers
{
    public class UploadController : BaseController
    {

        public ContentResult UploadImg()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                var data = new { code = 200, successFileLength = 1 };
                //JsonConvert.SerializeObject(data);
                return Content(JsonConvert.SerializeObject(data));//Content(UploadManager.UploadImg(files.Get("img")));
            }
            catch 
            {
                return Content(OutputHelper.GetOutputResponse(ResultCode.Error));
            }
        }
	}
}