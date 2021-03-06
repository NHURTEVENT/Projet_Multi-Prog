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
        public IButler Butler { get; set; }
        public Brush Color { get; set; }


        private ITable myTable;
        private IDisposable unsubscriber;


        public Client(IAction CurrentAction, string Name = "Lucien")
        {
            this.Name = Name;
            this.Type = PersonnelType.CLIENT;
            Color = Brushes.Purple;
            this.Position = MapKeyPoints.positions[MapPosition.CLIENT];
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0,0);

            Order = new List<Dish>();
            ActionQueue = new List<IAction>();
        }


        public Client(string Name = "Lucien")
        {
            this.Name = Name;
            this.Type = PersonnelType.CLIENT;
            Color = Brushes.Yellow;
            this.Position = MapKeyPoints.positions[MapPosition.CLIENT];
            //this.CurrentAction = CurrentAction;
            //RemainingTicks = CurrentAction.Duration;
            Position = new Point(0, 0);

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
                ChangeAction(ActionFactory.CreateAction_("Wait", this, MapPosition.CLIENT));
            else
                ChangeAction(ActionQueue[0]);
        }

        public void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " " + CurrentAction.Name);
            Logger.log += (Name + " " + CurrentAction.Name+"\n");
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
            Console.WriteLine("Le client s'est abonn� � la table");
            Logger.log += ("Le client s'est abonne a la table \n");

        }

        public void LeaveTable()
        {
            myTable.IsNowFree();
            unsubscriber.Dispose();

            this.Butler.ActionQueue.Add(ActionFactory.CreateAction_("CheckIn", this, MapPosition.CLIENT, this));
        }
        

        public void OnNext(ITable changes)
        {
            if (changes.state == "served")
            {
                ActionQueue.Add(ActionFactory.CreateAction_("Eat", this, MapPosition.TABLEX, this, this.myTable));
                ActionQueue.Add(ActionFactory.CreateAction_("LeaveTable", this, MapPosition.TABLEX, this, this.myTable));
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
