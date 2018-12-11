using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared
{
    public class StockEntry
    {
        [Key, Column(Order = 0)]
        public IngredientType Ingredient { get; set; }
        public int Quantity { get; set; }
        [Key, Column(Order = 1)]
        public DateTime ArrivalDate { get; set; }

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