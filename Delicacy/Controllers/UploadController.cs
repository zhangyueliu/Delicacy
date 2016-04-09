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

        public ActionResult UploadImgOne()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.AllKeys.Length; i++)
                {
                   HttpPostedFileBase file=  files[i];
                   string path= Server.MapPath("/Upload/Imagers/");
                   file.SaveAs(path+"abc.jpg");
                }
                //var data = new { code = 200, successFileLength = 1 };
                //JsonConvert.SerializeObject(data);
                //return Content("<input type='hidden' value='/Upload/Imagers/abc.jpg' id='upai_url'>");//Content(UploadManager.UploadImg(files.Get("img")));
                return View();
            }
            catch
            {
                return Content(OutputHelper.GetOutputResponse(ResultCode.Error));
            }
        }

        public ContentResult UploadImgTwo()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                var data = new { code = 200, successFileLength = 1 };
                //JsonConvert.SerializeObject(data);
                //return Content(JsonConvert.SerializeObject(data));//Content(UploadManager.UploadImg(files.Get("img")));
                return Content("<input type='hidden' value='/Upload/Images/abc.jpg' id='upai_url'>");//Content(UploadManager.UploadImg(files.Get("img")));
            }
            catch
            {
                return Content(OutputHelper.GetOutputResponse(ResultCode.Error));
            }
        }
	}
}