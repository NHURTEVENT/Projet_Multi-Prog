using System;
public class Kitchen {
	public Ustensil GetUstensil(ref String nom) {
		throw new System.Exception("Not implemented");
	}
	public void Operation() {
		throw new System.Exception("Not implemented");
	}

	private Machine machine;
	private Cupboard cupboard;
	private Counter counter;

	private KitchenPersonnel kitchenPersonnel;

}
