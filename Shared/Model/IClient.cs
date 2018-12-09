using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IClient : IPerson, IObserver<string>
    {

        void Book();
        void ConsumeWaterAndBread();
        void Pay();
        List<Dish> Order();
        void GetTable(ITable provider);

    }
}
