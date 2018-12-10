using Shared;
using System;
using System.Drawing;

namespace Model
{

    public class DishCleaner : IDishCleaner
    {

        public string Type { get; set; }
        public String Name { get; set; }
        public IAction CurrentAction { get; set; }
        public int RemainingTicks { get; set; }
        public Point Position { get; set; }

        public IAction GetAction()
        {
            throw new NotImplementedException();
        }

        public IKitchen GetKitchen()
        {
            throw new NotImplementedException();
        }

        public void Move(Point position)
        {
            throw new NotImplementedException();
        }

        Point GetPosition()
        {
            throw new NotImplementedException();
        }

        public DishCleaner(IAction CurrentAction, string Name = "Wash")
        {
            this.Name = Name;
            this.Type = "DishCleaner";
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0, 0);

        }

    }
}