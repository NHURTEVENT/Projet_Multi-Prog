using Shared;
using System;
using System.Collections.Generic;

namespace Model{
    public class Client : IClient
    {
        public string Name { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }



        public Client(IAction CurrentAction, string Name = "Lucien")
        {
            this.CurrentAction = CurrentAction;
            this.RemainingTicks = CurrentAction.Duration;
            this.Name = Name;
        }

        public void Book()
        {
            throw new NotImplementedException();
        }

        public void ConsumeWaterAndBread()
        {
            throw new NotImplementedException();
        }

        public List<Dish> GetOrder()
        {
            throw new NotImplementedException();
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }

        public void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " starts to " + CurrentAction.Name);
        }

        public void onTick()
        {
            RemainingTicks--;
            if (RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
                    case "Eat":
                        ChangeAction(ActionFactory.CreateAction_("Diggest"));
                        break;
                    case "Diggest":
                        ChangeAction(ActionFactory.CreateAction_("Wait"));
                        break;
                    case "Wait":
                        Console.WriteLine(Name + " is waiting");
                        RemainingTicks++;
                        break;
                    default:
                        break;
                }
            }
        }
        
    }

}
