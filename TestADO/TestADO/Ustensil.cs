using System;
public class Ustensil {

    public int ID { get; set; }

	public String name { get; set; }

    public Dish dish { get; set; }

    public Ustensil(string name, Dish dish)
    {
        this.name = name;
        this.dish = dish;
    }
}
