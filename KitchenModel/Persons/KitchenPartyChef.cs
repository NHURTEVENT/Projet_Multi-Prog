using System;
using System.Drawing;
using Shared;


namespace Model
{

    public class PartyChef : KitchenPersonnel
    {
        private String ustensil;
        private String currentDish;

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

        private KitchenClerk[] kitchenClerks;


    }
}