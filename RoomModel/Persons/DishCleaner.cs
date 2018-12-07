using Model;
using Shared;
using System;
using System.Drawing;

namespace Model
{
    public class DishCleaner : IPerson
    {
        public int remainingTicks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string currentAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public void setTask(string task)
        {
            throw new NotImplementedException();
        }
    }
}