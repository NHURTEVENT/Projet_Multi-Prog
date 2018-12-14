using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class ActionFactory
    {

        public static IAction CreateAction_(string Name = "Wait", IClient ClientConcerned = null, ITable TableConcerned = null, IOrder OrderConcerned = null)
        {
            switch (Name)
            {
                case "MoveToTable":
                    return new Action_("MoveToTable", 1, null, ClientConcerned, TableConcerned);

                case "Eat":
                    return new Action_("Eat", 3, null, ClientConcerned, TableConcerned);

                case "LeaveTable":
                    return new Action_("LeaveTable", 1, null, ClientConcerned, TableConcerned);

                case "LeaveRestaurant":
                    return new Action_("LeaveRestaurant", 1, null, ClientConcerned, TableConcerned);

                case "LookForTable":
                    return new Action_("LookForTable", 1, null, ClientConcerned, TableConcerned);

                case "CheckIn":
                    return new Action_("CheckIn", 1, null, ClientConcerned, TableConcerned);

                case "TakeClientInCharge":
                    return new Action_("TakeClientInCharge", 1, null, ClientConcerned, TableConcerned);

                case "MoveWithClient":
                    return new Action_("MoveWithClient", 1, null, ClientConcerned, TableConcerned);

                case "BringMenu":
                    return new Action_("BringMenu", 1, null, ClientConcerned, TableConcerned);

                case "TakeOrder":
                    return new Action_("TakeOrder", 1, null, ClientConcerned, TableConcerned);

                case "TransmitOrder":
                    return new Action_("TransmitOrder", 2, null, ClientConcerned, TableConcerned);

                case "DressTheTable":
                    return new Action_("DressTheTable", 1, null, ClientConcerned, TableConcerned);

                case "FetchOrder":
                    return new Action_("FetchOrder", 2, null, ClientConcerned, TableConcerned, OrderConcerned);

                case "BringOrder":
                    return new Action_("BringOrder", 2, null, ClientConcerned, TableConcerned);

                case "ClearTheTable":
                    return new Action_("ClearTheTable", 1, null, ClientConcerned, TableConcerned);

                case "TakeBread":
                    return new Action_("TakeBread", 1, null, ClientConcerned, TableConcerned);

                case "BringBread":
                    return new Action_("BringBread", 1, null, ClientConcerned, TableConcerned);

                case "TakeWater":
                    return new Action_("TakeWater", 1, null, ClientConcerned, TableConcerned);

                case "BringWater":
                    return new Action_("BringWater", 1, null, ClientConcerned, TableConcerned);

                default:
                    return new Action_("Wait", 1);

            }
        }

    }
}
