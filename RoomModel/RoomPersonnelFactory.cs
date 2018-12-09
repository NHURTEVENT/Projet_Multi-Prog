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

        public static IButler CreateButler(List<ITable> tables)
        {
            return new Butler(tables);
        }

        public static IHeadWaiter CreateHeadWaiter(List<ITable> tables)
        {
            return new HeadWaiter(tables);
        }
    }
}
