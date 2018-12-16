using Shared;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model {
	public class Waiter : IWaiter {

        public string Name { get; set; }
        public PersonnelType Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }
        public Brush Color { get; set; }


        public List<IAction> ActionQueue { get; set; }
        List<ITable> Tables;
        public List<IDisposable> TableUnsubscribers;
        public List<IOrder> WatchedOrder;
        List<IDisposable> OrderUnsubscriber;


        public Waiter(List<ITable> tables, ICounter counter)
        {
            this.Name = "Lucien";
            this.Type = PersonnelType.WAITER;
            this.Tables = tables;
            var a = MapKeyPoints.positions[MapPosition.WAITER];
            this.Position = MapKeyPoints.positions[MapPosition.WAITER];
            Color = Brushes.Red;
            ActionQueue = new List<IAction>();
            TableUnsubscribers = new List<IDisposable>();
            OrderUnsubscriber = new List<IDisposable>();


            foreach (ITable table in Tables)
            {
                TableUnsubscribers.Add(table.Subscribe(this));
                Console.WriteLine(Name + " observe the table");
                Logger.log += (Name + " observe the table\n");
            }
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


        public Point GetPosition()
        {
            return this.Position;
        }

        public void Move(Point position)
        {
            this.Position = position;
        }

        void ClearTable(ITable table)
        {
            table.IsNowClean();
        }

        public void FollowNewOrder(IOrder newOrder)
        {
            OrderUnsubscriber.Add(newOrder.Subscribe(this));
            Console.WriteLine(Name + " observe a new Order");
            Logger.log += (Name + " observe a new Order\n");
        }

        public void FetchOrder(IOrder order)
        {
            // TODO This function
        }

        public void BringOrder (ITable Table)
        {
            throw new NotImplementedException();
        }

        public void onTick()
        {
            RemainingTicks--;
            
            if(RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
                    case "ClearTheTable":
                        ClearTable(CurrentAction.TableConcerned);
                        CheckActionQueue();
                        break;

                    case "FetchOrder":
                        FetchOrder(CurrentAction.OrderConcerned);
                        CheckActionQueue();
                        break;

                    case "BringOrder":
                        BringOrder(CurrentAction.TableConcerned);
                        CheckActionQueue();
                        break;

                    default:
                        CheckActionQueue();
                        break;
                }
            }
        }

        private void CheckActionQueue()
        {
            if (ActionQueue.Count == 0)
            {
                ChangeAction(ActionFactory.CreateAction_("Wait", this, MapPosition.WAITER));
            }
            else
                ChangeAction(ActionQueue[0]);
        }

        public void OnNext(IOrder concernedOrder)
        {
            ActionQueue.Add(ActionFactory.CreateAction_("FetchOrder", this, MapPosition.TABLE1WAITER, null, null, concernedOrder));
            ActionQueue.Add(ActionFactory.CreateAction_("BringOrder", this, MapPosition.TABLE1WAITER, null, concernedOrder.Table, concernedOrder));

        }

        public void OnNext(ITable concernedTable)
        {
            if (concernedTable.state == "toClean")
            {
                ActionQueue.Add(ActionFactory.CreateAction_("ClearTheTable", this, MapPosition.TABLE1WAITER, null, concernedTable));
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
