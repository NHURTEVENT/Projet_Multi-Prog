using Shared;
using System;
using System.Collections.Generic;

namespace Shared
{
	public interface IButler : IPerson
    {
        
        bool FindTable(IClient currentClient);

    }

}
