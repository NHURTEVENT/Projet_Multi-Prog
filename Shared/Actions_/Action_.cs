using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Action_ : IAction
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public IClient ClientConcerned { get; set; }
        public ITable TableConcerned { get; set; }
        public IUtensil Ustensil { get; set; }
        public IOrder OrderConcerned { get; set; }


        public Action_(string Name, int Duration, IUtensil Ustensil = null, IClient ClientConcerned = null, ITable TableConcerned = null, IOrder OrderConcerned = null)
        {
            this.Name = Name;
            this.Duration = Duration;
            this.Ustensil = Ustensil;
            this.ClientConcerned = ClientConcerned;
            this.TableConcerned = TableConcerned;
        }
    }
}
