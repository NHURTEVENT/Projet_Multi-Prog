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
            return new Client(ActionFactory.CreateAction_("Eat"), Name);
        }

        public static IClient CreateClient(string Name)
        {
            return new Client(ActionFactory.CreateAction_(), Name);
        }

    }
}
