using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class RoomPersonnelFactory
    {

        public static IButler CreateButler(List<ITable> tables, List<IHeadWaiter> headWaiters)
        {
            return new Butler(tables, headWaiters);
        }

        public static IHeadWaiter CreateHeadWaiter(List<ITable> tables, ICounter counter)
        {
            return new HeadWaiter(tables, counter);
        }

        public static IWaiter CreateWaiter(List<ITable> tables, ICounter counter)
        {
            return new Waiter(tables, counter);
        }

        public static IClerk CreateClerk(List<ITable> tables)
        {
            return new RoomClerk(tables);
        }
    }
}
