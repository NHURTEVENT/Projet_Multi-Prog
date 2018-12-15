using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model {
	public class Waiter : IWaiter {

        public string Name { get; set; }
        public string Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }

        public IOrder CurrentOrder;
        public List<IAction> ActionQueue { get; set; }

        ICounter Counter;
        List<ITable> Tables;
        private IDisposable CounterUnsubscriber;
        public List<IDisposable> TableUnsubscribers;


        public Waiter(List<ITable> tables, ICounter counter)
        {
            this.Name = "Lucien";
            this.Type = "Waiter";
            this.Tables = tables;
            this.Counter = counter;

            ActionQueue = new List<IAction>();

            TableUnsubscribers = new List<IDisposable>();
            CounterUnsubscriber = Counter.Subscribe(this);

            foreach (ITable table in Tables)
            {
                TableUnsubscribers.Add(table.Subscribe(this));
                Console.WriteLine(Name + " observe the table");
            }

            ChangeAction(ActionFactory.CreateAction_());

        }


        private void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " " + CurrentAction.Name);
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

        public void FetchOrder(IOrder order)
        {
            Counter.RemoveOrder(order);
            this.CurrentOrder = order;
        }

        public void BringOrder (ITable Table)
        {
            Table.IsNowServed();
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
                        lock (ActionQueue)
                        {
                            ChangeAction(ActionFactory.CreateAction_("BringOrder", null, CurrentAction.OrderConcerned.Table, CurrentAction.OrderConcerned));
                        }
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
                ChangeAction(ActionFactory.CreateAction_());
            }
            else
                lock (ActionQueue)
                {
                    ChangeAction(ActionQueue[0]);
                }
        }

        public void OnNext(IOrder concernedOrder)
        {
            if (Tables.Contains(concernedOrder.Table))
            {
                lock (ActionQueue)
                {
                    ActionQueue.Add(ActionFactory.CreateAction_("FetchOrder", null, null, concernedOrder));
                }
            }

        }

        public void OnNext(ITable concernedTable)
        {
            if (concernedTable.state == "toClean")
            {
                lock (ActionQueue)
                {
                    ActionQueue.Add(ActionFactory.CreateAction_("ClearTheTable", null, concernedTable));
                }
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
