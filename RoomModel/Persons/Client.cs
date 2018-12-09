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

        private ITable myTable;
        private IDisposable unsubscriber;


        public Client(IAction CurrentAction, string Name = "Lucien")
        {
            this.Name = Name;
            this.Type = "Client";
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0,0);
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

        public List<Dish> Order()
        {
            throw new NotImplementedException();
        }


        public void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " starts to " + CurrentAction.Name);
        }

        public void onTick()
        {
            RemainingTicks--;
            if (RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
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
            ChangeAction(ActionFactory.CreateAction_("MoveToTable"));
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
