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

        private bool tableFound = true;

        public List<IAction> ActionQueue { get; set; }

        private List<ITable> tables;
        private List<IClient> checkInClients;
        private List<IHeadWaiter> headWaiters;


        public Butler(List<ITable> tables, List<IHeadWaiter> headWaiters)
        {
            this.Name = "Alfred";
            this.Type = "Butler";

            ActionQueue = new List<IAction>();

            this.tables = tables;
            ChangeAction(ActionFactory.CreateAction_());
            checkInClients = new List<IClient>();
            this.headWaiters = headWaiters;

        }

        public Point GetPosition()
        {
            return this.Position;
        }

        public void Move(Point position)
        {
            this.Position = position;
        }


        public void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " " + CurrentAction.Name);
            if (ActionQueue.Contains(Action))
            {
                ActionQueue.Remove(Action);
            }
        }

        private void CheckActionQueue()
        {
            if (ActionQueue.Count == 0)
            {
                ChangeAction(ActionFactory.CreateAction_());
            }
            else
                lock (ActionQueue)
                {
                    ChangeAction(ActionQueue[0]);
                }
        }

        public void onTick()
        {
            RemainingTicks--;

            if (RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
                    case "LookForTable":
                        tableFound = FindTable(CurrentAction.ClientConcerned);
                        if (tableFound)
                        {
                            CheckActionQueue();
                            tableFound = false;
                        }
                        else
                            RemainingTicks++;
                        break;

                    case "CheckIn":
                        CheckIn(CurrentAction.ClientConcerned);
                        CheckActionQueue();
                        break;

                    default:
                        CheckActionQueue();
                        break;
                }
                
            }

        }

        public bool FindTable(IClient currentClient)
        {
            bool tableFound = false;
            foreach (ITable table in tables)
            {
                if (table.state == "available")
                {
                    Console.WriteLine("Table trouvée");
                    tableFound = true;
                    table.IsNowOccuped();
                    lock (headWaiters[0].ActionQueue)
                    {
                        headWaiters[0].ActionQueue.Add(ActionFactory.CreateAction_("TakeClientInCharge", currentClient, table));
                    }
                    currentClient.Butler = this;
                    break;
                }
            }
            return tableFound;
        }

        public void CheckIn(IClient checkingInClient)
        {
            checkingInClient.Pay();
            lock (checkingInClient.ActionQueue)
            {
                checkingInClient.ActionQueue.Add(ActionFactory.CreateAction_("LeaveRestaurant"));
            }

        }

    }
}
