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
                    break;
                case "WaitForDish":
                    return new Action_("WaitForDish", 1);
                    break;
                case "WaitToPay":
                    return new Action_("WaitToPay", 1);
                    break;
                case "Eat":
                return new Action_("Eat", 3);
                    break;
                default:
                return new Action_("Wait", 1);
                    break;

            }
        }

    }
}
