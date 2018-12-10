using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IKitchenClerk
    {
        void redirect(IDish dish);
        void NewDish(List<IDish> newdish);
    }
}
