using System;
using System.Drawing;
using Model;
using Shared.Model;

public class KitchenClerk : KitchenPersonnel  {
	public Point GetPosition() {
		throw new System.Exception("Not implemented");
	}
	public void Move(ref Point position) {
		throw new System.Exception("Not implemented");
	}
	public IKitchen GetKitchen() {
		throw new System.Exception("Not implemented");
	}

    IKitchen KitchenPersonnel.GetKitchen()
    {
        throw new NotImplementedException();
    }

    Point IPersonnel.GetPosition()
    {
        throw new NotImplementedException();
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
