using System;
using System.Drawing;

public class PartyChef : KitchenPersonnel  {
	private String ustensil;
	private String currentDish;

	public void Cook(ref Dish dish) {
		throw new System.Exception("Not implemented");
	}
	public Point GetPosition() {
		throw new System.Exception("Not implemented");
	}
	public void Move(ref Point position) {
		throw new System.Exception("Not implemented");
	}
	public Kitchen GetKitchen() {
		throw new System.Exception("Not implemented");
	}

    Point IPersonnel.GetPosition()
    {
        throw new NotImplementedException();
    }

    private KitchenClerk[] kitchenClerks;


}
