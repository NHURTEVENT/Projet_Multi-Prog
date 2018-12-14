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


        public RoomClerk()
        {

            ActionQueue = new List<IAction>();
            ChangeAction(ActionFactory.CreateAction_());

        }

        public void RefillWater(ITable table)
        {
            throw new NotImplementedException();
        }

        public void RefillBread(ITable table)
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

        public void onTick()
        {
            RemainingTicks--;

            if (RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
                    case "RefillWater":
                        RefillWater(CurrentAction.TableConcerned);
                        CheckActionQueue();
                        break;

                    case "RefillBread":
                        RefillBread(CurrentAction.TableConcerned);
                        CheckActionQueue();
                        break;


                    default:
                        break;
                }
            }
        }

        public void OnNext(ITable table)
        {
            lock (ActionQueue)
            {

            }
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
