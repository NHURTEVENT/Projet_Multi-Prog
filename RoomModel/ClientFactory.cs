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

        public static IClient CreateEatingClient()
        {
            return new Client("Michel","Eating", 2);
        }

        public static IClient CreateClient()
        {
            return new Client();
        }

    }
}
