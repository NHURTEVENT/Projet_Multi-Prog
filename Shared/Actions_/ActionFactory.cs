using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class ActionFactory
    {

        public static IAction CreateAction_(string Name = "Wait")
        {
            switch (Name)
            {
                case "MoveToTable":
                    return new Action_("MoveToTable", 2);

                case "Eat":
                    return new Action_("Eat", 3);

                case "LeaveTable":
                    return new Action_("LeaveTable", 1);

                case "LeaveRestaurant":
                    return new Action_("LeaveRestaurant", 1);

                case "LooksForTable":
                    return new Action_("LooksForTable", 1);

                case "CheckIn":
                    return new Action_("CheckIn", 1);

                //case "MoveWithClient":
                //    return new Action_("MoveWithClient", 1);

                case "BringMenu":
                    return new Action_("BringMenu", 1);

                case "TakeOrder":
                    return new Action_("TakeOrder", 1);

                case "TransmitOrder":
                    return new Action_("TransmitOrder", 2);

                case "DressTheTable":
                    return new Action_("DressTheTable", 1);

                case "TakeDishes":
                    return new Action_("TakeDishes", 1);

                case "BringDishes":
                    return new Action_("BringDishes", 2);

                case "ClearTheTable":
                    return new Action_("ClearTheTable", 1);

                case "TakeBread":
                    return new Action_("TakeBread", 1);

                case "BringBread":
                    return new Action_("BringBread", 1);

                case "TakeWater":
                    return new Action_("TakeWater", 1);

                case "BringWater":
                    return new Action_("BringWater", 1);

                default:
                    return new Action_("Wait", 1);

            }
        }

    }
}
