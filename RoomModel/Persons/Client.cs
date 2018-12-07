using Shared;
using System;
using System.Collections.Generic;

namespace Model{
    public class Client : IClient
    {
        public string Name { get; set; }
        public int RemainingTicks { get; set; }
        public IAction CurrentAction { get; set; }



        public Client(string Name = "Lucien", IAction CurrentAction = null, int RemainingTicks = 3)
        {
            this.CurrentAction = CurrentAction;
            this.RemainingTicks = RemainingTicks;
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

        
    }

}
