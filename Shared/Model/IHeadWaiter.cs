using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IHeadWaiter : IPerson, IObserver<string>
    {

        List<Dish> ClientOrder { get; set; }

        void takeClientInCharge(IClient client, ITable table);
        void TakeOrder(IClient client);


    }
}
