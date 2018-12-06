using System;
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

	private KitchenClerk[] kitchenClerks;


}
