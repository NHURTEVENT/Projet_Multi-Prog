using Shared;
using System;
using System.Drawing;

namespace Model {
	public class HeadWaiter : IHeadWaiter
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }


        public Point GetPosition()
        {
            throw new NotImplementedException();
        }

        public void Move(Point position)
        {
            throw new NotImplementedException();
        }

        public void TakeOrder(IClient client)
        {
            throw new NotImplementedException();
        }

        public void DressTable(ITable table)
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

        public void OnNext(string value)
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }

}
