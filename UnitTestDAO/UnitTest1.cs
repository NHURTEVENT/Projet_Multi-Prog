using System;
using KitchenModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDAO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenConfigurationFileReturnsConnectionString()
        {
            TestWrapper wrapper = new TestWrapper();
            Assert.IsNotNull(wrapper.getConnectionString());
        }

        [TestMethod]
        public void GivenDatabaseConnects()
        {
            TestWrapper wrapper = new TestWrapper();
            Assert.IsNotNull(wrapper.testConnection(wrapper.getConnectionString()));
        }
    }
}
