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
        public List<Dish> Dishes { get; set; }


        public HeadWaiter(List<ITable> tables)
        {
            this.Name = "Michel";
            this.Type = "HeadWaiter";

            this.Tables = tables;
            Dishes = new List<Dish>();
            Unsubscribers = new List<IDisposable>();

            foreach (var table in Tables)
            {
                Unsubscribers.Add(table.Subscribe(this));
                Console.WriteLine(Name + " s'est abonné à la table");
            }

            ChangeAction(ActionFactory.CreateAction_());

        }


        public Point GetPosition()
        {
            throw new NotImplementedException();
        }

        public void Move(Point position)
        {
            throw new NotImplementedException();
        }

        public void TakeOrder(IClient client)
        {
            this.Dishes = client.Dishes;
        }

        public void DressTable(ITable table)
        {
            throw new NotImplementedException();
        }

        public void onTick()
        {
            throw new NotImplementedException();
        }

        public void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " starts to " + CurrentAction.Name);
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
