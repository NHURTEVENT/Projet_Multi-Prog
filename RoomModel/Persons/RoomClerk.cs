using Shared;
using System;
using System.Drawing;

namespace Model {
	public class RoomClerk : IPerson {
        public int remainingTicks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string currentAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
    }

}
