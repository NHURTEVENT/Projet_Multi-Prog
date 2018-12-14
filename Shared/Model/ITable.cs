using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Shared
{
    public interface ITable : IObservable<ITable>
    {

        int squareNumber { get; set; }
        int row { get; set; }
        int column { get; set; }
        Point position { get; set; }
        int size { get; set; }
        string state { get; set; }

        void IsNowOccuped();
        void IsNowAvailable();
        void IsNowServed();
        void IsNowFree();
        void IsNowClean();

    }
}
