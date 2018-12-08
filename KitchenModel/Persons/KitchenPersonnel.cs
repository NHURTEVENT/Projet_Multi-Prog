using System;
using System.Drawing;
using Shared;

namespace Model
{

    public class KitchenPersonnel //: IPerson
    {
        public int remainingTicks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string currentAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Point GetPosition()
        {
            throw new NotImplementedException();
        }

        public void Move(Point position)
        {
            throw new NotImplementedException();
        }

        public void setTask(string task)
        {
            throw new NotImplementedException();
        }

        IKitchen GetKitchen()
        {
            return null;
        }
        // method move is inherited from base class

        // method getPosition is inherited from base class


    }
}