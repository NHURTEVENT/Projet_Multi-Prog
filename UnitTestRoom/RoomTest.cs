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

            var client = new Client(ActionFactory.CreateAction_());
            Assert.AreEqual(client.GetType(), ClientFactory.CreateClient().GetType());

        }
    }


    [TestClass]
    public class ActionFactoryTest
    {
        [TestMethod]
        public void TestCreateAction()
        {

            var action = new Action_("Wait", 1);
            Assert.AreEqual(action.Name, ActionFactory.CreateAction_("Wait").Name);
            Assert.AreEqual(action.Duration, ActionFactory.CreateAction_("Wait").Duration);

        }
    }



    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestChangeAction()
        {
            var client = ClientFactory.CreateClient();
            var action = new Action_("Eat", 3);
            client.ChangeAction(ActionFactory.CreateAction_("Eat"));

            Assert.AreEqual(action.Name, client.CurrentAction.Name);
            Assert.AreEqual(action.Duration, client.RemainingTicks);

        }
    }

}
