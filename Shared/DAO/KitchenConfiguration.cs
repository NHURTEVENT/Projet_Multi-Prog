using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class KitchenConfiguration
    {
        public List<PersonnelDBEntry> PersonnelDBEntries { get; set; }
        public List<Drawer> Drawers { get; set; }
        public List<MachineDBEntry> MachineDBEntries { get; set; }
        public List<RecipeStep> Recipes { get; set; }
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
