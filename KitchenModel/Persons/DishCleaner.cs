using Shared;
using System;
using System.Drawing;

namespace Model
{

    public class DishCleaner : KitchenPersonnel
    {
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
    }
}