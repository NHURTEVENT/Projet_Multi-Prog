using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Controller;
using Shared;
using System.Collections.Generic;

namespace UnitTestRoom
{
    [TestClass]
    public class ClientFactoryTest
    {
        [TestMethod]
        public void TestCreateClient()
        {

            var client = new Client();
            client.ChangeAction(ActionFactory.CreateAction_("Wait", client, MapPosition.CLIENT));
            Assert.AreEqual(client.GetType(), ClientFactory.CreateClient("client1").GetType());

        }
    }

    [TestClass]
    public class RoomPersonnelFactoryTest
    {

        List<ITable> tables = new List<ITable>();
        List<IHeadWaiter> headWaiters = new List<IHeadWaiter>();


        [TestMethod]
        public void TestCreateButler()
        {
            var butler = new Butler(tables, headWaiters);
            Assert.AreEqual(butler.GetType(), RoomPersonnelFactory.CreateButler(tables, headWaiters).GetType());

        }

        [TestMethod]
        public void TestCreateHeadWaiter()
        {
            var headWaiter = new HeadWaiter(tables);
            var headWaiter2 = RoomPersonnelFactory.CreateHeadWaiter(tables);
            Assert.AreEqual(headWaiter.GetType(), headWaiter2.GetType());
        }

    }

    [TestClass]
    public class ActionFactoryTest
    {
        [TestMethod]
        public void TestCreateAction()
        {

            var action = new Action_("Wait", 1, MapPosition.CLIENT);
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
            var client = ClientFactory.CreateClient("eatingClient1");
            var action = new Action_("Eat", 3, MapPosition.CLIENT, client);
            client.ChangeAction(ActionFactory.CreateAction_("Eat", client));

            Assert.AreEqual(action.Name, client.CurrentAction.Name);
            Assert.AreEqual(action.Duration, client.RemainingTicks);

        }
    }


    [TestClass]
    public class HeadWaiterTest
    {

        List<ITable> tables = new List<ITable>();


        [TestMethod]
        public void TestTakeOrder()
        {
            var client = ClientFactory.CreateClient("Client1");
            IHeadWaiter headWaiter = RoomPersonnelFactory.CreateHeadWaiter(tables);

            client.Order.Add(Dish.CHICKEN);

            headWaiter.TakeOrder(client);

            Assert.AreEqual(client.Order, headWaiter.ClientOrder);

        }
    }


}
