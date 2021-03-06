﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IClient : IPerson, IObserver<ITable>
    {
        List<Dish> Order { get; set; }
        IButler Butler { get; set; }

        void Book();
        void ConsumeWaterAndBread();
        void Pay();
        List<Dish> GiveOrder();
        void GetTable(ITable provider);

    }
}
