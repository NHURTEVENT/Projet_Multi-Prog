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
        public IPerson Person { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public IClient ClientConcerned { get; set; }
        public ITable TableConcerned { get; set; }
        public IUtensil Ustensil { get; set; }
        public IOrder OrderConcerned { get; set; }


        public Action_( string Name, int Duration, MapPosition Position, IPerson Person = null, IUtensil Ustensil = null, IClient ClientConcerned = null, ITable TableConcerned = null, IOrder OrderConcerned = null)
        {
            this.Name = Name;
            this.Duration = Duration;
            this.Ustensil = Ustensil;
            this.Person = Person;
            this.ClientConcerned = ClientConcerned;
            this.TableConcerned = TableConcerned;
            if(Position == MapPosition.TABLEX)
            {
                if(TableConcerned != null)
                {
                    //switch on table.ID and set corresponding position
                    Person.Position = MapKeyPoints.positions[MapPosition.TABLE1];
                }                    
                else
                {
                    throw new ArgumentException("no table found for action " + Name);
                }
            }
            else
            {
                Person.Position = MapKeyPoints.positions[Position];
            }
        }
    }
}
