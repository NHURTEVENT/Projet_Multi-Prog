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
        IButler butler;
        List<IClient> clients = new List<IClient>();
        List<IPerson> personnel = new List<IPerson>();
        List<ITable> tables = new List<ITable>();

        public RoomManager(List<IClient> clients/*, Configuration config*/)
        {
            this.clients = clients;
            tables.Add(new Table());
            IButler butler = RoomPersonnelFactory.CreateButler(tables);

        }

        public void onTick(Object myObject, EventArgs myEventArgs)
        {

            butler.onTick();

            foreach (IPerson member in personnel)
            {
                member.onTick();

            }
            foreach (IClient client in clients)
            {
                client.onTick();

            }
        }

        public void onNewClient(List<IClient> newClientList)
        {

            butler.NewClient(newClientList);

        }

    }
}
