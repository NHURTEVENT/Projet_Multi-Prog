using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ClientGenerator
    {

        private List<IClient> newClientList;
        private int RemainingTicks;
        private int ClientNumber = 1;
        private string ClientName = "client";

        public ClientGenerator()
        {
            newClientList = new List<IClient>();
            newClientList.Clear();
            RemainingTicks = 2;
        }

        public IClient onTick()
        {
            IClient newClient = null;
            RemainingTicks--;

            if (RemainingTicks == 0)
            {
                newClient = ClientFactory.CreateClient(ClientName + ClientNumber);
                ClientNumber++;
                RemainingTicks = 20;
            }

            return newClient;
        }

    }
}
