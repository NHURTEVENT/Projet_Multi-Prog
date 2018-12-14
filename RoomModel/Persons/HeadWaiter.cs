using Shared;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model {
    public class HeadWaiter : IHeadWaiter
    {

        public string Name { get; set; }
        public PersonnelType Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }

        public List<IDisposable> Unsubscribers;
        public List<ITable> Tables;
        public List<Dish> ClientOrder { get; set; }
        public List<IAction> ActionQueue { get; set; }


        public HeadWaiter(List<ITable> tables)
        {
            this.Name = "Michel";
            this.Type = PersonnelType.HEADWAITER;

            this.Tables = tables;
            ClientOrder = new List<Dish>();
            Unsubscribers = new List<IDisposable>();
            ActionQueue = new List<IAction>();

            foreach (var table in Tables)
            {
                Unsubscribers.Add(table.Subscribe(this));
                Console.WriteLine(Name + " s'est abonn� � la table");
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
            ActionQueue.Add(ActionFactory.CreateAction_("MoveWithClient", currentClient, clientTable));
            ActionQueue.Add(ActionFactory.CreateAction_("BringMenu", null, clientTable));
            ActionQueue.Add(ActionFactory.CreateAction_("TakeOrder", currentClient, clientTable));
            ActionQueue.Add(ActionFactory.CreateAction_("TransmitOrder", null, clientTable));

            // Test HeadWaiter serve the dishes
            ActionQueue.Add(ActionFactory.CreateAction_("BringDishes", null, clientTable));

        }

        public void TakeOrder(IClient client)
        {
            this.ClientOrder = client.GiveOrder();
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
                ChangeAction(ActionQueue[0]);
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
                        CurrentAction.ClientConcerned.ActionQueue.Add(ActionFactory.CreateAction_("MoveToTable", null, CurrentAction.TableConcerned));
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

                    // Test HeadWaiter serve the dishes
                    case "BringDishes":
                        CurrentAction.TableConcerned.IsNowServed();
                        CheckActionQueue();
                        break;

                    default:
                        CheckActionQueue();
                        break;
                }
            }
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

        private void TransmitOrder()
        {
            Console.WriteLine("HeadWaiter just transmit order");
            // Socket Serveur --- send order + Table --> Client
        }


        public void OnNext(ITable concernedTable)
        {
            if (concernedTable.state == "toDress")
            {
                ActionQueue.Add(ActionFactory.CreateAction_("DressTheTable", null, concernedTable));
            }


            if (concernedTable.state == "toClean")
            {
                concernedTable.IsNowClean();
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
