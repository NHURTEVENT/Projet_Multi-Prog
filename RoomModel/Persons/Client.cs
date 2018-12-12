using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model{
    public class Client : IClient
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }
        public List<Dish> Order { get; set; }
        public List<IAction> ActionQueue { get; set; }
        public IButler Butler { get; set; }

        private ITable myTable;
        private IDisposable unsubscriber;


        public Client(IAction CurrentAction, string Name = "Lucien")
        {
            this.Name = Name;
            this.Type = "Client";
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0,0);

            Order = new List<Dish>();
            ActionQueue = new List<IAction>();
        }


        public void Book()
        {
            throw new NotImplementedException();
        }

        public void ConsumeWaterAndBread()
        {
            throw new NotImplementedException();
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }

        public Point GetPosition()
        {
            return this.Position;
        }

        public void Move(Point position)
        {
            this.Position = position;
        }

        public List<Dish> GiveOrder()
        {
            return this.Order;
        }


        private void CheckActionQueue()
        {
            if (ActionQueue.Count == 0)
                ChangeAction(ActionFactory.CreateAction_());
            else
                ChangeAction(ActionQueue[0]);
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

        public void onTick()
        {
            RemainingTicks--;

            if (RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
                    case "MoveToTable":
                        GetTable(CurrentAction.TableConcerned);
                        CheckActionQueue();
                        break;

                    case "Eat":
                        CheckActionQueue();
                        break;

                    case "LeaveTable":
                        LeaveTable();
                        CheckActionQueue();
                        break;

                    case "LeaveRestaurant":
                        RemainingTicks++;
                        break;

                    default:
                        CheckActionQueue();
                        break;
                }
            }
        }

        public void GetTable(ITable table)
        {
            unsubscriber = table.Subscribe(this);
            myTable = table;
            Console.WriteLine("Le client s'est abonné à la table");
        }

        public void LeaveTable()
        {
            myTable.IsNowFree();
            unsubscriber.Dispose();

            this.Butler.ActionQueue.Add(ActionFactory.CreateAction_("CheckIn", this));
        }
        

        public void OnNext(ITable changes)
        {
            if (changes.state == "served")
            {
                ActionQueue.Add(ActionFactory.CreateAction_("Eat"));
                ActionQueue.Add(ActionFactory.CreateAction_("LeaveTable"));
            }
        }


        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }

}
