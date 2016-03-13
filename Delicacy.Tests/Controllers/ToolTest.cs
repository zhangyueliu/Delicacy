using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tool;

namespace Delicacy.Tests.Controllers
{
    [TestClass]
    public class ToolTest
    {
        [TestMethod]
        public void IsNullOrEmpty()
        {
            Assert.IsFalse(CheckParameter.IsNullOrEmpty("fadsf", null, "asdf", ""),"CheckParameter.IsNullOrEmpty"); ;
        }

        [TestMethod]
        public void SendEmail()
        {
            EmailHelper.SendEmail("title", "http://www.baidu.com", "1084727879@qq.com");

        }
    }
}
