using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Model
{
    public static class ClientFactory
    {

        public static IClient CreateEatingClient(string Name)
        {
            var client = new Client(Name);
            client.ChangeAction(ActionFactory.CreateAction_("Eat", (IPerson)client,MapPosition.CLIENT));
            return client;
        }

        public static IClient CreateClient(string Name)
        {

            var client = new Client(Name);
            client.ChangeAction(ActionFactory.CreateAction_("Wait",(IPerson)client, MapPosition.CLIENT));
            return client;
        }

    }
}
