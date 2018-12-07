using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Shared;

namespace UnitTestRoom
{
    [TestClass]
    public class ClientFactoryTest
    {
        [TestMethod]
        public void TestCreateClient()
        {

            var client = new Client();
            Assert.AreEqual(client.GetType(), ClientFactory.CreateClient().GetType());

        }
    }





}
