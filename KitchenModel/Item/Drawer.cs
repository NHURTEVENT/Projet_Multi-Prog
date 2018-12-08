using Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model{
    public class Drawer
    {
        public int Quantity { get; set; }

        [Key]
        public Utensil Ustensil { get; set; }

        /*public IUtensil GetUstensil(String nom)
        {
            throw new System.Exception("Not implemented");
        }*/

       


    }
}