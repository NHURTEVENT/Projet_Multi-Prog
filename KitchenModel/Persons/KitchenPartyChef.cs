using System;
using System.Drawing;
using Shared;
using System.Collections.Generic;



namespace Model
{

    public class PartyChef : IKitchenPartyChef
    {
        private String ustensil;
        private String currentDish;

        public string Type { get; set; }
        public String Name { get; set; }
        public IAction CurrentAction { get; set; }
        public int RemainingTicks { get; set; }
        public Point Position { get; set; }
        public List<Dish> DishOrder { get; set; }
        public List<IAction> KActionQueue { get; set; }

        private IDish mydish;


        public PartyChef(IAction CurrentAction, string Name = "Remy")
        {
            this.Type = "PartyChef";
            this.Name = Name;
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0, 0);

            DishOrder = new List<Dish>();
            KActionQueue = new List<IAction>();

        }

        public void Cook(ref Dish dish)
        {
            throw new System.Exception("Not implemented");
        }
        public Point GetPosition()
        {
            return this.Position;
        }
        public void Move(ref Point position)
        {
            throw new NotImplementedException();
        }
        public IKitchen GetKitchen()
        {
            throw new System.Exception("Not implemented");
        }

        public List<Dish> GiveOrderDish()
        {
            return this.DishOrder;
        }

        public void Move(Point position)
        {
            this.Position = position; throw new NotImplementedException();
        }

        public IAction GetAction()
        {
            throw new NotImplementedException();
        }

        public List<Dish> GiveDishOrder()
        {
            return this.DishOrder;
        }

        private void ChangeAction (IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + "Starts to" + CurrentAction);
            if (KActionQueue.Contains(Action))
            {
                KActionQueue.Remove(Action);
            }
        }

        

        public void onTick()
        {
            RemainingTicks--;
            if (RemainingTicks == 0)
            {
                if (KActionQueue.Count == 0)
                {
                    ChangeAction(KitchenActionFactory.CreateKitchenAction_());
                }
                else
                {
                    ChangeAction(KActionQueue[0]);
                }
            }

            if (RemainingTicks == 0)
            {
                switch (CurrentAction.Name)
                {
                    case "DishNotFound":
                        ChangeAction(KitchenActionFactory.CreateKitchenAction_("Prepare"));
                        break;

                    case "DishFound":
                        ChangeAction(KitchenActionFactory.CreateKitchenAction_("Cook"));
                        break;

                    case "Called";
                        ChangeAction(KitchenActionFactory.CreateKitchenAction_("Call clerk"));
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine(this.Name + " " + this.CurrentAction.Name);
            }
        }

        public void cook(IDish dish)
        {
            throw new NotImplementedException();
        }

        public void setTask(string task)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        private KitchenClerk[] kitchenClerks;


    }
}