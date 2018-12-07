using Shared.Model;
using System;
using System.Collections.Generic;

namespace Controller {
	public class Waiter : IWaiter {
		
        void IWaiter.CleanTable()
        {
            throw new NotImplementedException();
        }

        public void GiveOrder(ref object client_iClient)
        {
            throw new NotImplementedException();
        }

        public void FetchOrder(ref List<Dish> order)
        {
            throw new NotImplementedException();
        }

        public void GiveOrder(IClient client)
        {
            throw new NotImplementedException();
        }
    }

}
