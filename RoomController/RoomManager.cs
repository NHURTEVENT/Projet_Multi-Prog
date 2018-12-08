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
        List<IClient> clients = new List<IClient>();
        List<IPerson> personnel = new List<IPerson>();

        public RoomManager(List<IClient> clients/*, Configuration config*/)
        {
            this.clients = clients;
        }

        public void onTick(Object myObject, EventArgs myEventArgs)
        {

            foreach (IClient client in clients)
            {
                client.onTick();

            }
        }
    }
}
