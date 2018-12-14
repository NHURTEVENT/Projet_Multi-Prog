using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IOrder
    {

        int OrderNum { get; set; }
        List<Dish> Dishes { get; set; }
        ITable Table { get; set; }

    }
}
