using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IAction
    {

        int ID { get; set; }
        string Name { get; set; }
        int Duration { get; set; }
        IUstensil Ustensil { get; set; }

    }
}