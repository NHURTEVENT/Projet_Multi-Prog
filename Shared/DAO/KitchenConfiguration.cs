using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    /// <summary>
    /// Contains all the all relevant information about the kitchen
    /// the information is fetched in the database
    /// </summary>
    public class KitchenConfiguration
    {
        //All the personnel of the kitchen
        //gives the number of each type of personnel
        public List<PersonnelDBEntry> PersonnelDBEntries { get; set; }
        //All the utensils in the kitchen
        //gives the number of each type of utensil
        public List<Drawer> Drawers { get; set; }
        //All the machines in the kitchen
        //gives all the caracterisitcs of each machine
        public List<MachineDBEntry> MachineDBEntries { get; set; }
        //All the steps of all the recipes
        public List<RecipeStep> Recipes { get; set; }
        //All stock entries
        public List<StockEntry> Stocks { get; set; }

        public KitchenConfiguration(List<PersonnelDBEntry> personnelDBEntries, List<Drawer> drawers, List<MachineDBEntry> machineDBEntries, List<RecipeStep> recipes, List<StockEntry> stocks)
        {
            PersonnelDBEntries = personnelDBEntries;
            Drawers = drawers;
            MachineDBEntries = machineDBEntries;
            Recipes = recipes;
            Stocks = stocks;
        }
    }
}
