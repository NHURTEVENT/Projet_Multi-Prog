using Shared;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Model
{
    public class Table : ITable
    {
        public string squareNumber { get; set; }
        public string row { get; set; }
        public string position { get; set; }
        public int size { get; set; }
        public string state { get; set; }
        List<IObserver<ITable>> observers;

        public Table()
        {
            this.state = "available";
            this.size = 4;
            
            observers = new List<IObserver<ITable>>();

        }


        public void IsNowOccuped()
        {
            lock (state)
            {
                state = "occuped";
            }
        }

        public void IsNowAvailable()
        {
            lock (state)
            {
                state = "available";
            }
        }

        public void IsNowServed()
        {
            OnChange("dishServed");
        }

        public void IsNowFree()
        {
            OnChange("dishFinished");
        }

        public void IsNowClean()
        {
            OnChange("deserved");
        }

        public IDisposable Subscribe(IObserver<ITable> observer)
        {
            if (! observers.Contains(observer))
                observers.Add(observer) ;

            return new TableUnsubscriber(observers, observer);
        }
        
        public void OnChange(string changeType)
        {
            lock (state)
            {
                lock (observers)
                {
                    switch (changeType)
                    {
                        case "dishServed":
                            this.state = "served";
                            foreach (var observer in observers)
                            {
                                observer.OnNext(this);
                            }
                            break;

                        case "dishFinished":
                            this.state = "toClean";
                            foreach (var observer in observers)
                            {
                                observer.OnNext(this);
                            }
                            break;

                        case "breadFinished":
                            this.state = "toRefill";
                            foreach (var observer in observers)
                            {
                                observer.OnNext(this);
                            }
                            break;

                        case "deserved":
                            this.state = "toDress";
                            foreach (var observer in observers)
                            {
                                observer.OnNext(this);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}