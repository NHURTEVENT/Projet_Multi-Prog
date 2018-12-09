﻿using System;
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

            var client = new Client(ActionFactory.CreateAction_());
            Assert.AreEqual(client.GetType(), ClientFactory.CreateClient("client1").GetType());

        }
    }

    [TestClass]
    public class RoomPersonnelFactoryTest
    {

        List<ITable> tables = new List<ITable>();


        [TestMethod]
        public void TestCreateButler()
        {
            var butler = new Butler(tables);
            Assert.AreEqual(butler.GetType(), RoomPersonnelFactory.CreateButler(tables).GetType());

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

            var action = new Action_("Wait", 1);
            Assert.AreEqual(action.Name, ActionFactory.CreateAction_("Wait").Name);
            Assert.AreEqual(action.Duration, ActionFactory.CreateAction_("Wait").Duration);

        }
    }



    [TestClass]
    public class RoomManagerTest
    {
        [TestMethod]
        public void TestclearClients()
        {
            RoomManager roomManager = new RoomManager();
            List<IClient> newClientList = new List<IClient>();
            var client = ClientFactory.CreateClient("runningAwayClient");
            client.ChangeAction(ActionFactory.CreateAction_("Leaved"));
            newClientList.Add(client);

            roomManager.newClients(newClientList);
            roomManager.clientsLeaving.Add(client);

            roomManager.clearClients();

            Assert.AreEqual(0, roomManager.clients.Count);

        }
    }


    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestChangeAction()
        {
            var client = ClientFactory.CreateClient("eatingClient1");
            var action = new Action_("Eat", 3);
            client.ChangeAction(ActionFactory.CreateAction_("Eat"));

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

            client.Dishes.Add(Dish.Riz_de_veau);

            headWaiter.TakeOrder(client);

            Assert.AreEqual(client.Dishes, headWaiter.Dishes);

        }
    }


}
