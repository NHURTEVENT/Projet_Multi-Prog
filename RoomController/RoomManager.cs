using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RoomManager : IManager
    {
        ClientGenerator clientGenerator;
        IButler butler;
        public List<IClient> clients { get; set; }
        public List<IClient> clientsLeaving { get; set; }
        public List<IPerson> personnel { get; set; }
        public List<ITable> tables { get; set; }


        public RoomManager(/*, Configuration config*/)
        {
            clients = new List<IClient>();
            clientsLeaving = new List<IClient>();
            personnel = new List<IPerson>();
            tables = new List<ITable>();

            tables.Add(new Table());
            butler = RoomPersonnelFactory.CreateButler(tables);
            clientGenerator = new ClientGenerator();

        }

        public void onTick(Object myObject, EventArgs myEventArgs)
        {
            newClients(clientGenerator.onTick());

            butler.onTick();

            foreach (IPerson member in personnel)
            {
                member.onTick();

            }
            foreach (IClient client in clients)
            {
                if (client.CurrentAction.Name == "Leaved")
                    clientsLeaving.Add(client);
                else
                    client.onTick();

            }

            clearClients();

        }

        public void clearClients()
        {
            if (clientsLeaving.Count != 0)
            {
                foreach (var client in clientsLeaving)
                {
                    clients.Remove(client);
                }
                clientsLeaving.Clear();
            }
        }

        public void newClients(List<IClient> newClientList)
        {
            if (newClientList.Count > 0)
            {
                this.clients.AddRange(newClientList);
                butler.NewClient(newClientList);
            }

        }

    }
}
