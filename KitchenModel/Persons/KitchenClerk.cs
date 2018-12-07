using System;
using System.Drawing;
using Model;
using Shared.Model;

public class KitchenClerk : IKitchenPersonnel  {
	public Point GetPosition() {
		throw new System.Exception("Not implemented");
	}
	public void Move(ref Point position) {
		throw new System.Exception("Not implemented");
	}
	public IKitchen GetKitchen() {
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

    public string getCurrentAction()
    {
        throw new NotImplementedException();
    }

    public void setTask(string task)
    {
        throw new NotImplementedException();
    }

    public int getRemainingTicks()
    {
        throw new NotImplementedException();
    }

    public void setRemainingTicks(int tick)
    {
        throw new NotImplementedException();
    }
}
