using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IHeadWaiter : IPerson, IObserver<ITable>
    {

        List<Dish> ClientOrder { get; set; }

        void TakeClientInCharge(IClient currentClient, ITable clientTable);
        void TakeOrder(IClient client);


    }
}
