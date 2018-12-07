using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IClient
    {
        int RemainingTicks { get; set; }
        IAction CurrentAction { get; set; }
        string Name { get; set; }

        void Book();
        void ConsumeWaterAndBread();
        void Pay();
        List<Dish> GetOrder();
        
    }
}
