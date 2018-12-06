using Model;
using Shared.DAO;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomController
{
    public class RoomManager : IManager
    {
        List<IPerson> persons = new List<IPerson>();

        public RoomManager(List<IPerson> persons, Configuration config)
        {
            this.persons = persons;
        }

        public void onTick(Object myObject, EventArgs myEventArgs)
        {
            //Console.WriteLine("DING DING");

            foreach (IPerson person in persons)
            {
                person.setRemainingTicks(person.getRemainingTicks()-1);

                if (person.getRemainingTicks() == 0)
                {
                    //person.getCurrentAction().release();
                    //TODO : trier la liste des actions
                    //TODO : si il y a une action dansla liste, la faire
                    //TODO : choisir une nouvelle tâche en fonction de plein de trucs et la acquire()
                    switch (person.getCurrentAction())
                    {
                        case "eating":
                            person.setTask("digest");
                            break;
                        case "waiting":
                            person.setTask("eating");
                            break;
                        /*case PersonsTypes.HeadWaiter:
                            break;
                        case PersonsTypes.Waiter:
                            break;
                        case PersonsTypes.RoomCommis:
                            break;*/
                    }
                }
            }
        }
    }
}
