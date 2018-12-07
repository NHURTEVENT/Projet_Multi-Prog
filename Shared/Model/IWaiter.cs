using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public interface IWaiter
    {
        void CleanTable();
        void GiveOrder(IClient client);
        void FetchOrder(ref List<Dish> order);

    }
}
