﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public interface IHeadWaiter
    {
        void TakeOrder(IClient client);
        void DressTable(ITable table);

    }
}
