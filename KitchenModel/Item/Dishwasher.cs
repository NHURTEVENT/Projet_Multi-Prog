using Shared;
using System;
using System.Drawing;

namespace Model
{
    public class Dishwasher : Machine
    {
        public string Type { get; set; }
        public String Name { get; set; }
        public IAction CurrentAction { get; set; }
        public int RemainingTicks { get; set; }
        public Point Position { get; set; }
        public int MaxCapacity { get; set; }
        public int MinCapacity { get; set; }


        public Dishwasher(IAction CurrentAction, string Name = "DishWash")
        {
            this.MaxCapacity = 24;
            this.MinCapacity = 1;
            this.Name = Name;
            this.Type = "DishWasher";
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0, 0);

        }

    }
    }
}