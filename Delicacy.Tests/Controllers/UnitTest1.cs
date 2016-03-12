using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delicacy;
using Delicacy.Controllers;
using System.Web.Mvc;
using Tool;
using Newtonsoft.Json;
namespace Delicacy.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RegisterAndLoginController registerController = new RegisterAndLoginController();
          string contResult=  registerController.Register("1084727879@qq.com", "123456").Content;
          OutputModel model= JsonConvert.DeserializeObject<OutputModel>(contResult);
          //Assert.AreEqual(model.StatusCode, 1);
          Assert.IsNotNull(model);
        }
    }
}
