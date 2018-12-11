using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Action_ : IAction
    {

        public string Name { get; set; }
        public int Duration { get; set; }
        public int ID { get; set; }
        public IUtensil Ustensil { get; set; }

        public Action_(string Name, int Duration, IUtensil Ustensil = null)
        {
            this.Name = Name;
            this.Duration = Duration;
            this.Ustensil = Ustensil;
        }

    }
}
