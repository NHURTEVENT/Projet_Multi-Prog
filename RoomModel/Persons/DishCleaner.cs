using Model;
using Shared.Model;
using System;
using System.Drawing;

public class DishCleaner : KitchenPersonnel  {
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
}
