using Shared;
using System;
using System.Drawing;

namespace Model {
	public class HeadWaiter : IPerson
    {

        public int remainingTicks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string currentAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAction CurrentAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RemainingTicks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void TakeOrder(IClient client)
        {
            throw new NotImplementedException();
        }

        public void DressTable(ITable table)
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
