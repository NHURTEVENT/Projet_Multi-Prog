using System;
using System.Drawing;
using Shared;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Model;

namespace Model
{

    public class KitchenChef : IKitchenChef
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }
        public Point Position { get; set; }
        public List<IDish> Dishes;
        public IDish DishInCharge;
        private IAction action;

        public List<Dish> DishOrder { get; set; }
        public List<IAction> KActionQueue { get; set; }
        
        public KitchenChef(List<IDish> dishes)
        {
            this.Name = "Auguste";
            this.Type = "KitchenChef";

            this.Dishes = dishes;
            DishOrder = new List<Dish>();
            KActionQueue = new List<IAction>();

            ChangeAction(KitchenActionFactory.CreateKitchenAction_());
        }

        public KitchenChef(IAction action, string name)
        {
            this.action = action;
            Name = name;
        }

        public Point GetPosition()
        {
            return this.Position;
        }
        public void Move(ref Point position)
        {
            throw new System.Exception("Not implemented");
        }
        public IKitchen GetKitchen()
        {
            throw new System.Exception("Not implemented");
        }

        public void Move(Point position)
        {
            this.Position = position;
        }

        public void TakeDishInCharge(IDish dish)
        {
            this.DishInCharge = dish;
            
            KActionQueue.Add(KitchenActionFactory.CreateKitchenAction_("TakeDishOrder"));
            KActionQueue.Add(KitchenActionFactory.CreateKitchenAction_("GiveDishOrder"));

        }

        public void TakDishOrder(IKitchenPartyChef PartyChef)
        {
            this.DishOrder = PartyChef.GiveDishOrder();
        }

        public IAction GetAction()
        {
            throw new NotImplementedException();
        }

        public void onTick()
        {
            switch (CurrentAction.Name)
            {
                case "TakeDishInCharge":
                    ChangeAction(KitchenActionFactory.CreateKitchenAction_("TakeDish"));
                    break;

                case "TakeDishOrder":
                    TakeDishInCharge(DishInCharge);
                        ChangeAction(KitchenActionFactory.CreateKitchenAction_("TakeDishOrder"));
                    break;

                case "GiveDishOrder":
                    TakeDishInCharge(DishInCharge);
                    ChangeAction(KitchenActionFactory.CreateKitchenAction_("TakeDishOrder"));
                    break;

                default:
                    break;
            }

            if (KActionQueue.Count == 0)
            {
                ChangeAction(KitchenActionFactory.CreateKitchenAction_());
            }
            else
            {
                ChangeAction(KActionQueue[0]);
            }
        }

        /*public KitchenChef(IAction CurrentAction, string Name = "ToOrder")
        {
            this.Name = Name;
            this.Type = "KitchenChef";
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0, 0);

        }*/

        public void ChangeAction(IAction Action)
        {
            this.CurrentAction = Action;
            RemainingTicks = Action.Duration;
            Console.WriteLine(Name + " starts to " + CurrentAction.Name);
            if (KActionQueue.Contains(Action))
            {
                KActionQueue.Remove(Action);
            }
        }

        public void TakeDishOrder(IKitchenPartyChef PartyChef)
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
    }

        public PartyChef[] partyChefs;

    }
}