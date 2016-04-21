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
            EmailHelper.SendEmail("食谱网", "亮亮亮亮,我是悦悦http://www.baidu.com", "1084727879@qq.com");

        }
    }
}
