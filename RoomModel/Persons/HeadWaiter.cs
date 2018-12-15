using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model {
	public class HeadWaiter : IHeadWaiter
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }

        public List<IDisposable> Unsubscribers;
        public List<ITable> Tables;
        public ICounter Counter;
        public IOrder ClientOrder { get; set; }
        public List<IAction> ActionQueue { get; set; }


        public HeadWaiter(List<ITable> tables, ICounter counter)
        {
            this.Name = "Michel";
            this.Type = "HeadWaiter";

            this.Counter = counter;
            this.Tables = tables;
            Unsubscribers = new List<IDisposable>();
            ActionQueue = new List<IAction>();

            foreach (var table in Tables)
            {
                Unsubscribers.Add(table.Subscribe(this));
                Console.WriteLine(Name + " observe the table");
            }

            ChangeAction(ActionFactory.CreateAction_());

        }


        public Point GetPosition()
        {
            return this.Position;
        }

        public void Move(Point position)
        {
            this.Position = position;
        }


        public void TakeClientInCharge(IClient currentClient, ITable clientTable)
        {
            lock (ActionQueue)
            {
                ActionQueue.Add(ActionFactory.CreateAction_("MoveWithClient", currentClient, clientTable));
                ActionQueue.Add(ActionFactory.CreateAction_("BringMenu", null, clientTable));
                ActionQueue.Add(ActionFactory.CreateAction_("TakeOrder", currentClient, clientTable));
                ActionQueue.Add(ActionFactory.CreateAction_("TransmitOrder", null, clientTable));
            }
        }

        public void TakeOrder(IClient client)
        {
            this.ClientOrder = client.GiveOrder();
            this.ClientOrder.Table = CurrentAction.TableConcerned;
        }

        public void DressTable(ITable table)
        {
            table.IsNowAvailable();
        }


        private void CheckActionQueue()
        {
            if (ActionQueue.Count == 0)
                ChangeAction(ActionFactory.CreateAction_());
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
                    case "TakeClientInCharge":
                        TakeClientInCharge(CurrentAction.ClientConcerned, CurrentAction.TableConcerned);
                        lock (ActionQueue)
                        {
                            CurrentAction.ClientConcerned.ActionQueue.Add(ActionFactory.CreateAction_("MoveToTable", null, CurrentAction.TableConcerned));
                        }
                        CheckActionQueue();
                        break;

                    case "MoveWithClient":
                        CheckActionQueue();
                        break;

                    case "BringMenu":
                        CheckActionQueue();
                        break;

                    case "TakeOrder":
                        TakeOrder(CurrentAction.ClientConcerned);
                        CheckActionQueue();
                        break;

                    case "TransmitOrder":
                        TransmitOrder();
                        CheckActionQueue();
                        break;

                    case "DressTheTable":
                        DressTable(CurrentAction.TableConcerned);
                        CheckActionQueue();
                        break;

                    default:
                        CheckActionQueue();
                        break;
                }
            }
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

        private void TransmitOrder()
        {
            // Socket Serveur --- send order + Table --> Client
            Counter.AddOrder(ClientOrder);
            Console.WriteLine("Order transmited");
        }


        public void OnNext(ITable concernedTable)
        {
            if (concernedTable.state == "toDress")
            {
                lock (ActionQueue)
                {
                    ActionQueue.Add(ActionFactory.CreateAction_("DressTheTable", null, concernedTable));
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
