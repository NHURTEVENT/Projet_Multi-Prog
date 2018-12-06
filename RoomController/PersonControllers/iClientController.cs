using System;
using System.Collections.Generic;

namespace Controller {
	public class Client : IClient {
		
        void IClient.Book()
        {
            throw new NotImplementedException();
        }

        List<Dish> IClient.GetOrder()
        {
            throw new NotImplementedException();
        }

        void IClient.ConsumeWaterAndBread()
        {
            throw new NotImplementedException();
        }

        void IClient.Pay()
        {
            throw new NotImplementedException();
        }
    }

}
