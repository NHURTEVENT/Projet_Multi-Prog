﻿using Model;
using Shared;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RoomManager : IManager
    {
        public int ticks;
        ClientGenerator clientGenerator;
        IButler butler;
        public List<IClient> clients { get; set; }
        public List<IClient> clientsLeaving { get; set; }
        public List<IHeadWaiter> headWaiters { get; set; }
        public List<IWaiter> waiters { get; set; }
        public List<IClerk> clerks { get; set; }
        public List<ITable> tables { get; set; }
        public List<IButler> butlers { get; set; }
        public List<IPerson> Peoples { get; set; }


        public RoomManager( Configuration config)
        {
            ticks = 1;
            clients = new List<IClient>();
            clientsLeaving = new List<IClient>();
            headWaiters = new List<IHeadWaiter>();
            waiters = new List<IWaiter>();
            clerks = new List<IClerk>();
            tables = new List<ITable>();

            tables.Add(new Table());
            butler = RoomPersonnelFactory.CreateButler(tables, headWaiters);
            headWaiters.Add(RoomPersonnelFactory.CreateHeadWaiter(tables));
            clientGenerator = new ClientGenerator();

        }

        public void onTick(Object myObject, EventArgs myEventArgs)
        {
            Console.WriteLine("");
            Console.WriteLine(ticks);

            newClient(clientGenerator.onTick());

            butler.onTick();

            foreach (IHeadWaiter headWaiter in headWaiters)
            {
                headWaiter.onTick();

            }

            foreach (IClient client in clients)
            {
                if (client.CurrentAction.Name == "LeaveRestaurant")
                    clientsLeaving.Add(client);
                else
                    client.onTick();

            }
            
            if(clientsLeaving.Count > 0)
                foreach (var client in clientsLeaving)
                {
                    clients.Remove(client);
                }
            clientsLeaving.Clear();

            ticks++;
        }

        public void newClient(IClient newClient)
        {
            if (newClient != null)
            {
                Console.WriteLine("New Client");
                this.clients.Add(newClient);
                butler.ActionQueue.Add(ActionFactory.CreateAction_("LookForTable", newClient));
            }

        }

    }
}
