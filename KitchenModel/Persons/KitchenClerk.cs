using System;
using System.Drawing;
using Shared;


namespace Model
{

    public class KitchenClerk : KitchenPersonnel
    {
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
    }
}