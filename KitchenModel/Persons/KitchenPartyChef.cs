using System;
using System.Drawing;
using Model;
using Shared.Model;

public class PartyChef : IKitchenPersonnel  {
	private String ustensil;
	private String currentDish;

	public void Cook(Dish dish) {
		throw new System.Exception("Not implemented");
	}
	public Point GetPosition() {
		throw new System.Exception("Not implemented");
	}
	public void Move(Point position) {
		throw new System.Exception("Not implemented");
	}
	public IKitchen GetKitchen() {
		throw new System.Exception("Not implemented");
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

    private KitchenClerk[] kitchenClerks;


}
