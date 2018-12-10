using System;
using System.Drawing;
using Shared;
using System.Drawing;
using Shared;



namespace Model
{

    public class KitchenClerk : IKitchenClerk
    {

        public string Type { get; set; }
        public String Name { get; set; }
        public IAction CurrentAction { get; set; }
        public int RemainingTicks { get; set; }
        public Point Position { get; set; }

        public Point GetPosition()
        {
            throw new System.Exception("Not implemented");
        }
        public void Move(ref Point position)
        {
            throw new System.Exception("Not implemented");
        }
        public IKitchen GetKitchen()
        {
            throw new System.Exception("Not implemented");
        }

        public void Move(Point position)
        {
            throw new NotImplementedException();
        }

        public IAction GetAction()
        {
            throw new NotImplementedException();
        }

        public KitchenClerk(IAction CurrentAction, string Name = "Bring")
        {
            this.Name = Name;
            this.Type = "KitchenClerk";
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0, 0);

        }
    }
}