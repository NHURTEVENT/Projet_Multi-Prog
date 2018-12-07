using Shared.Model;
using System;
using System.Collections.Generic;

namespace Controller {
	public class WaiterController : IWaiterController {
		
        public void CleanTable()
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
