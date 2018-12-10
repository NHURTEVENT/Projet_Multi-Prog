using Shared;
using System;
using System.Text;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Model
{

    public class KitchenChef : IKitchenChef
    {

        public string Type { get; set; }
        public String Name { get; set; }
        public IAction CurrentAction { get; set; }
        public int RemainingTicks { get; set; }
        public Point Position { get; set; }

        public Point GetPosition()
        {
            throw new System.Exception("Not implemented");
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
            throw new NotImplementedException();
        }

        public IAction GetAction()
        {
            throw new NotImplementedException();
        }

        public KitchenChef(IAction CurrentAction, string Name = "ToOrder")
        {
            this.Name = Name;
            this.Type = "KitchenChef";
            this.CurrentAction = CurrentAction;
            RemainingTicks = CurrentAction.Duration;
            Position = new Point(0, 0);

        }

        }

        private PartyChef[] partyChefs;

    }
}