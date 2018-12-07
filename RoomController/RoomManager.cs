using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RoomManager : IManager
    {
        List<IClient> clients = new List<IClient>();

        public RoomManager(List<IClient> clients/*, Configuration config*/)
        {
            this.clients = clients;
        }

        public void onTick(Object myObject, EventArgs myEventArgs)
        {

            foreach (IClient client in clients)
            {
                client.RemainingTicks--;

                if (client.RemainingTicks == 0)
                {
                    //person.getCurrentAction().release();
                    //TODO : trier la liste des actions
                    //TODO : si il y a une action dansla liste, la faire
                    //TODO : choisir une nouvelle tâche en fonction de plein de trucs et la acquire()
                    switch (client.CurrentAction)
                    {
                        case "Waiting":
                            client.CurrentAction = "Eating";
                            client.RemainingTicks = 1;
                            Console.WriteLine(client.Name + " " + client.CurrentAction);
                            break;
                        case "Eating":
                            client.CurrentAction = "Digest";
                            client.RemainingTicks = 1;
                            Console.WriteLine(client.Name + " " + client.CurrentAction);
                            break;
                        case "Digest":
                            client.CurrentAction = "Waiting";
                            Console.WriteLine(client.Name + " " + client.CurrentAction);
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
