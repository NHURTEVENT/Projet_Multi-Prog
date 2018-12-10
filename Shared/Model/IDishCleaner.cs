using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IDishCleaner
    {
        void CleanUstensil(IUstensil ustensil);
        void CleanDish(IDish dish);

    }
}
