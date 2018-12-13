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

        public List<IAction> ActionQueue { get; set; }
        List<ITable> Tables;

        public Waiter(List<ITable> tables)
        {
            this.Name = "Lucien";
            this.Type = "Waiter";
            this.Tables = tables;
            ActionQueue = new List<IAction>();
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


        void CleanTable()
        {
            CurrentAction.TableConcerned.IsNowClean();
        }
        
        public void FetchOrder(ref List<Dish> order)
        {
            throw new NotImplementedException();
        }

        public void GiveOrder(IClient client)
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

        public void setTask(string task)
        {
            throw new NotImplementedException();
        }

        public void onTick()
        {
            throw new NotImplementedException();
        }


    }

}
