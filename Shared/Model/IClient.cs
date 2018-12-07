using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IClient
    {
        void Book();
        void ConsumeWaterAndBread();
        List<Dish> GetOrder();
        void Pay();
    }
}
