using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Shared
{
    public interface ITable
    {

        string squareNumber { get; set; }
        string row { get; set; }
        string position { get; set; }
        int size { get; set; }
        bool available { get; set; }

        void IsOccuped();

    }
}
