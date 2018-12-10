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
        public IClient ClientInCharge;
        public ITable ClientTable;
        public List<Dish> ClientOrder { get; set; }
        public List<IAction> ActionQueue { get; set; }

        public HeadWaiter(List<ITable> tables)
        {
            this.Name = "Michel";
            this.Type = "HeadWaiter";

            this.Tables = tables;
            ClientOrder = new List<Dish>();
            Unsubscribers = new List<IDisposable>();
            ActionQueue = new List<IAction>();

            foreach (var table in Tables)
            {
                Unsubscribers.Add(table.Subscribe(this));
                Console.WriteLine(Name + " s'est abonné à la table");
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


        public void takeClientInCharge(IClient client, ITable table)
        {

            this.ClientInCharge = client;
            this.ClientTable = table;

            ActionQueue.Add(ActionFactory.CreateAction_("MoveWithClient"));
            ActionQueue.Add(ActionFactory.CreateAction_("BringMenu"));
            ActionQueue.Add(ActionFactory.CreateAction_("TakeOrder"));
            ActionQueue.Add(ActionFactory.CreateAction_("GiveOrder"));


        }

        public void TakeOrder(IClient client)
        {
            this.ClientOrder = client.GiveOrder();
        }

        public void DressTable(ITable table)
        {
            throw new NotImplementedException();
        }

        public void onTick()
        {
            RemainingTicks--;

            if (RemainingTicks == 0)
            {

                switch (CurrentAction.Name)
                {
                    case "TakeClientInCharge":
                        ClientInCharge.ActionQueue.Add(ActionFactory.CreateAction_("MoveToTable"));
                        break;

                    case "MoveWithClient":
                        ClientInCharge.GetTable(ClientTable);
                        ChangeAction(ActionFactory.CreateAction_("BringMenu"));
                        break;

                    case "BringMenu":
                        TakeOrder(ClientInCharge);
                        ChangeAction(ActionFactory.CreateAction_("TakeOrder"));
                        break;

                    case "TakeOrder":
                        ClientInCharge.
                        ChangeAction(ActionFactory.CreateAction_("GiveOrder"));
                        break;

                    default:
                        break;
                }

                if (ActionQueue.Count == 0)
                {
                    ChangeAction(ActionFactory.CreateAction_());
                }
                else
                {
                    ChangeAction(ActionQueue[0]);
                }

            }
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

        public void OnNext(string value)
        {
            throw new NotImplementedException();
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
