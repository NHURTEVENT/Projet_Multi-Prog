using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IUstensil
    {
        int ID { get; set; }

        String name { get; set; }

        Dish? dish { get; set; }
    }
}
