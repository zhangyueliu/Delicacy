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
    public class UserInfoControllerTest
    {
        UserInfoController registerController = new UserInfoController();
        
        
        [TestMethod]
        public void Register()
        {
            string loginId = "cl889521@163.com";
            string pwd = "123456";
            pwd = MD5Helper.convertToMD5(pwd);
            
            string contResult = registerController.Register(loginId, pwd).Content;
          OutputModel model= JsonConvert.DeserializeObject<OutputModel>(contResult);
          Assert.AreEqual(model.StatusCode, 1);
          //Assert.IsNotNull(model);
        }

        [TestMethod]
        public void  Login()
        {
            string loginId = "cl889521@163.com";
            string pwd = "123456";
            pwd = MD5Helper.convertToMD5(pwd);
            string result = registerController.Login(loginId, pwd).Content;
            OutputModel model = JsonConvert.DeserializeObject<OutputModel>(result);
            Assert.AreEqual(model.StatusCode, 1);
        }
       
    }
}
