using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model
{
	public class Butler : IButler
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IAction CurrentAction { get; set; }
        public int RemainingTicks { get; set; }
        public Point Position { get; set; }

        private List<ITable> tables;
        private List<IClient> newClientList;


        public Butler(List<ITable> tables)
        {
            this.Name = "Alfred";
            this.Type = "Butler";
            this.tables = tables;
            ChangeAction(ActionFactory.CreateAction_());
            newClientList = new List<IClient>();

        }

        public Point GetPosition()
        {
            throw new NotImplementedException();
        }

        public void Move(Point position)
        {
            Position = position;
        }



        public void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " starts to " + CurrentAction.Name);
        }

        public void Redirect(IClient client)
        {
            throw new NotImplementedException();
        }

        public void onTick()
        {
            RemainingTicks--;

            switch (CurrentAction.Name)
            {
                case "Wait":
                    if (newClientList.Contains(null))
                        FindTable(newClientList[0]);
                    else
                    {
                        RemainingTicks++;
                        Console.WriteLine(Name + " the " + this.Type + " is waiting");
                    }
                    break;
                default:
                    break;
            }
        }

        public void NewClient(List<IClient> newClients)
        {
            newClientList.AddRange(newClients);
        }

        public void FindTable(IClient currentClient)
        {
            foreach (ITable table in tables)
            {
                if (table.available)
                {
                    table.IsOccuped();
                    currentClient.GetTable(table);
                    break;
                }
            }
        }
    }

}
