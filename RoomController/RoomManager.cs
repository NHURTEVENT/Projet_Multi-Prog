using Model;
using Shared;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RoomManager : IManager
    {
        public int ticks;
        ClientGenerator clientGenerator;
        IButler butler;
        public List<IClient> clients { get; set; }
        public List<IClient> clientsLeaving { get; set; }
        public List<IHeadWaiter> headWaiters { get; set; }
        public List<IWaiter> waiters { get; set; }
        public List<IClerk> clerks { get; set; }
        public List<ITable> tables { get; set; }
        public List<IButler> butlers { get; set; }
        public List<IPerson> Peoples { get; set; }


        public RoomManager(Configuration config)
        {
            ticks = 1;
            clients = new List<IClient>();
            clientsLeaving = new List<IClient>();
            headWaiters = new List<IHeadWaiter>();
            waiters = new List<IWaiter>();
            clerks = new List<IClerk>();
            tables = new List<ITable>();
            //these are unique for now but we make it a list for latter evolutivity
            butlers = new List<IButler>();
            Peoples = new List<IPerson>();
            //get values from the config and create corresponding objects
            setUpPersonnel(config);
            

            clientGenerator = new ClientGenerator();
            butler = butlers.ElementAt(0);

        }

        public void setUpPersonnel(Configuration config)
        {
            //create tables
            tables = RoomPersonnelFactory.createTables(config.RoomConfig.TableDBEntries);
            //create personnel
            List<PersonnelDBEntry> perso = config.RoomConfig.PersonnelDBEntries;
            perso = perso.OrderBy(p => p.PersonnelType).ToList();
            perso = perso.Where(p => (p.PersonnelType == PersonnelType.BUTLER) || (p.PersonnelType == PersonnelType.HEADWAITER) || (p.PersonnelType == PersonnelType.WAITER)).ToList();

            foreach (PersonnelDBEntry entry in perso)
            {
                for (int i = 0; i < entry.Quantity; i++)
                {
                    Peoples.Add(RoomPersonnelFactory.createPerson(entry.PersonnelType));
                }
            }

            butlers = Peoples.Where(p => (p.Type == PersonnelType.BUTLER)).ToList().Cast<IButler>().ToList();
            //waiters = Peoples.Where(p => (p.Type == PersonnelType.WAITER)).ToList().Cast<IWaiter>().ToList();
            headWaiters = Peoples.Where(p => (p.Type == PersonnelType.HEADWAITER)).ToList().Cast<IHeadWaiter>().ToList();

            //perso.ForEach(p => Peoples.Add(RoomPersonnelFactory.createPerson(p.PersonnelType)));

            //list avec des ipersonnel
            //sort la list en plusieurs listes de chaque type
        }

        public void onTick(Object myObject, EventArgs myEventArgs)
        {
            Console.WriteLine("");
            Console.WriteLine(ticks);

            Logger.log +="\n";
            Logger.log +=(ticks + "\n");
            newClient(clientGenerator.onTick());

            butler.onTick();

            foreach (IHeadWaiter headWaiter in headWaiters)
            {
                headWaiter.onTick();

            }

            foreach (IClient client in clients)
            {
                if (client.CurrentAction.Name == "LeaveRestaurant")
                    clientsLeaving.Add(client);
                else
                    client.onTick();

            }
            
            if(clientsLeaving.Count > 0)
                foreach (var client in clientsLeaving)
                {
                    clients.Remove(client);
                    Peoples.Remove(client);
                }
            clientsLeaving.Clear();

            ticks++;
        }

        public void newClient(IClient newClient)
        {
            if (newClient != null)
            {
                Console.WriteLine("New Client");
                Logger.log += "New Client\n";
                this.clients.Add(newClient);
                Peoples.Add(newClient);
                butler.ActionQueue.Add(ActionFactory.CreateAction_("LookForTable", butler, MapPosition.BUTLER, newClient));
            }

        }

    }
}
