using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model {
	public class RoomClerk : IClerk {

        public string Name { get; set; }
        public string Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }

        public List<IAction> ActionQueue { get; set; }
        private List<IDisposable> Unsubscribers;
        private List<ITable> Tables;

        public RoomClerk(List<ITable> tables)
        {
            this.Name = "Marcel";
            this.Type = "Clerk";

            this.Tables = tables;

            ActionQueue = new List<IAction>();
            Unsubscribers = new List<IDisposable>();

            foreach (ITable table in tables)
            {
                Unsubscribers.Add(table.Subscribe(this));
                Console.WriteLine(Name + " observe the table");
            }

            ChangeAction(ActionFactory.CreateAction_());

        }

        public void FetchWater()
        {
            // TODO +1 semaphore water containers
        }

        public void FetchBread()
        {
            // TODO +1 semaphore bread basket
        }

        public void RefillWater(ITable table)
        {
            table.Refilled();
        }

        public void RefillBread(ITable table)
        {
            table.Refilled();
        }

        public Point GetPosition()
        {
            return this.Position;
        }

        public void Move(Point position)
        {
            this.Position = position;
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

        public void onTick()
        {
            RemainingTicks--;

            if (RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
                    case "FetchWater":
                        FetchWater();
                        CheckActionQueue();
                        break;

                    case "RefillWater":
                        RefillWater(CurrentAction.TableConcerned);
                        CheckActionQueue();
                        break;

                    case "FetchBread":
                        FetchBread();
                        CheckActionQueue();
                        break;

                    case "RefillBread":
                        RefillBread(CurrentAction.TableConcerned);
                        CheckActionQueue();
                        break;

                    default:
                        CheckActionQueue();
                        break;
                }
            }
        }

        public void OnNext(ITable table)
        {
            lock (ActionQueue)
            {
                switch (table.lack)
                {
                    case "water":
                        ActionQueue.Add(ActionFactory.CreateAction_("FetchWater"));
                        ActionQueue.Add(ActionFactory.CreateAction_("RefillWater", null, table));
                        break;

                    case "bread":
                        ActionQueue.Add(ActionFactory.CreateAction_("FetchBread"));
                        ActionQueue.Add(ActionFactory.CreateAction_("RefillBread", null, table));
                        break;

                    default:
                        break;
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
