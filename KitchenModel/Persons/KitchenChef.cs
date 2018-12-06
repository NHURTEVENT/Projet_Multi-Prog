using System;
public class KitchenChef : KitchenPersonnel  {
	public Point GetPosition() {
		throw new System.Exception("Not implemented");
	}
	public void Move(ref Point position) {
		throw new System.Exception("Not implemented");
	}
	public Kitchen GetKitchen() {
		throw new System.Exception("Not implemented");
	}

	private PartyChef[] partyChefs;

}
