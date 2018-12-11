using Shared;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model{
    public class Client : IClient
    {
        public string Name { get; set; }
        public PersonnelType Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }
        public List<Dish> Order { get; set; }
        public List<IAction> ActionQueue { get; set; }

        private ITable myTable;
        private IDisposable unsubscriber;


        public Client(IAction CurrentAction, string Name = "Lucien")
        {
            this.Name = Name;
            this.Type = PersonnelType.CLIENT;
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


        public void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " starts to " + CurrentAction.Name);
            if (ActionQueue.Contains(Action))
            {
                ActionQueue.Remove(Action);
            }
        }

        public void onTick()
        {
            RemainingTicks--;
            //if (RemainingTicks == 0)
            //{

            //    if (ActionQueue.Count == 0)
            //    {
            //        ChangeAction(ActionFactory.CreateAction_());
            //    }
            //    else
            //    {
            //        ChangeAction(ActionQueue[0]);
            //    }

            //}

            if (RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
                    case "TableFound":
                        ChangeAction(ActionFactory.CreateAction_("MoveToTable"));
                        break;

                    case "MoveToTable":
                        ChangeAction(ActionFactory.CreateAction_("Eat"));
                        break;

                    case "Eat":
                        ChangeAction(ActionFactory.CreateAction_("Diggest"));
                        break;

                    case "Diggest":
                        ChangeAction(ActionFactory.CreateAction_("Leave"));
                        break;

                    case "Leave":
                        LeaveTable();
                        ChangeAction(ActionFactory.CreateAction_("Leaved"));
                        break;

                    case "Wait":
                        Console.WriteLine(Name + " is waiting");
                        RemainingTicks++;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine(this.Name + " " + this.CurrentAction.Name);
            }
        }

        public void GetTable(ITable table)
        {
            unsubscriber = table.Subscribe(this);
            myTable = table;
            Console.WriteLine("Le client s'est abonné à la table");
            CurrentAction.Name = "TableFound";
        }

        public void LeaveTable()
        {
            myTable.IsNowFree();
            unsubscriber.Dispose();
        }
        

        public void OnNext(string changes)
        {
            switch (changes)
            {
                case "dishServed":
                    ChangeAction(ActionFactory.CreateAction_("Eat"));
                    break;

                default:
                    break;
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
