using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared
{
    /// <summary>
    /// Ingredients in stock
    /// updated everyday on products arrival
    /// Decremented when an ingredient is used to prepare a dish
    /// </summary>
    public class StockEntry
    {
        //Composite primary key
        //Ingredient concerned
        [Key, Column(Order = 0)]
        public IngredientType Ingredient { get; set; }
        //Date of ingredient's arrival in the stock
        //used to sort out spoiled food
        [Key, Column(Order = 1)]
        public DateTime ArrivalDate { get; set; }
        
        //Quantity left in stock
        public int Quantity { get; set; }

        public StockEntry()
        {
        }

        public StockEntry(IngredientType ingredient, int quantity, DateTime arrivalDate)
        {
            Ingredient = ingredient;
            Quantity = quantity;
            ArrivalDate = arrivalDate;
        }
    }
}