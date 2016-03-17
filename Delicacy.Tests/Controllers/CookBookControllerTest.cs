using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delicacy;
using Delicacy.Models;
using Delicacy.Controllers;
using System.Web.Mvc;
using Tool;

namespace Delicacy.Tests.Controllers
{
    [TestClass]
    public class CookBookControllerTest
    {
        [TestMethod]
        public void  AddCookBook()
        {
            CookBookModel cbModel = new CookBookModel()
            {
                Description = "ceshi",
                FinalImg = "abc.jpg",
                FoodMaterial = "1",
                FoodSort = "1",
                Name = "很好吃的菜",
                ProcessImgDes = "abc.jpg::第一步",
                Status = "0",
                Taste = "1",
                Tips = "多放盐"
            };
            CookBookController cbController = new CookBookController();
            ContentResult cResult= cbController.PublishCookBook(cbModel)  as ContentResult;
            OutputModel model= JsonHelper.UnserializeString(cResult.Content) as OutputModel;
            Assert.AreEqual(model.StatusCode, 1);
        }
    }
}
