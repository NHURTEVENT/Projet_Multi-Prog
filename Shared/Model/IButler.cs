using Shared;
using System;
using System.Collections.Generic;

namespace Shared
{
	public interface IButler : IPerson
    {
        
        void Redirect(IClient client);
        void NewClient(List<IClient> newClient);
        bool FindTable(IClient currentClient);


    }

}
