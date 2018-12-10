using System;
using System.Drawing;
using Shared;
using System.Collections.Generic;



namespace Model
{

    public class PartyChef : IKitchenPartyChef
    {
        private String ustensil;
        private String currentDish;

        public string Type { get; set; }
        public String Name { get; set; }
        public IAction CurrentAction { get; set; }
        public int RemainingTicks { get; set; }
        public Point Position { get; set; }

        public void Cook(ref Dish dish)
        {
            throw new System.Exception("Not implemented");
        }
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

        public PartyChef(IAction CurrentAction, string Name = "Lasagne")
        {
            this.Name = Name;
            this.Type = "PartyChef";
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0, 0);

        }

        private KitchenClerk[] kitchenClerks;


    }
}