using Shared;
using Shared.Model;
using System;
using System.Drawing;

namespace Model {
	public class RoomClerk : IPerson {
        public int remainingTicks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string currentAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAction CurrentAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RemainingTicks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PersonnelType Type { get; set; }

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

        public void onTick()
        {
            throw new NotImplementedException();
        }

        public void ChangeAction(IAction Action)
        {
            throw new NotImplementedException();
        }
    }

}
