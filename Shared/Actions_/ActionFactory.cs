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
                case "WaitOutside":
                    return new Action_("WaitOutside", 1);

                case "WaitForDish":
                    return new Action_("WaitForDish", 1);

                case "WaitToPay":
                    return new Action_("WaitToPay", 1);

                case "Eat":
                    return new Action_("Eat", 3);

                case "LooksForTable":
                    return new Action_("LooksForTable", 1);

                case "MoveToTable":
                    return new Action_("MoveToTable", 2);

                case "MoveWithClient":
                    return new Action_("MoveWithClient", 1);

                case "TakeOrder":
                    return new Action_("TakeOrder", 1);

                case "Diggest":
                    return new Action_("Diggest", 3);

                case "Leave":
                    return new Action_("Leave", 1);

                case "Leaved":
                    return new Action_("Leaved", 1);

                default:
                    return new Action_("Wait", 1);

            }
        }

    }
}
