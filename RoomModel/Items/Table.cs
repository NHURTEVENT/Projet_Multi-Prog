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
        public bool available { get; set; }
        public bool dishServed { get; set; }
        public bool dishFinished { get; set; }
        public bool breadFinished { get; set; }

        List<IObserver<string>> observers;

        public Table()
        {
            this.available = true;
            this.size = 4;

            dishFinished = false;
            dishServed = false;
            breadFinished = false;

            observers = new List<IObserver<string>>();

        }


        public void IsNowOccuped()
        {
            this.available = false;
        }

        public void IsNowFree()
        {
            this.available = true;
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            if (! observers.Contains(observer))
                observers.Add(observer) ;

            return new TableUnsubscriber(observers, observer);
        }
        

        public void OnChange(string changeType)
        {
            switch (changeType)
            {
                case "dishServed":
                    this.dishServed = true;
                    foreach (var observer in observers)
                    {
                        observer.OnNext(changeType);
                    }
                    break;

                case "dishFinished":
                    this.dishFinished = true;
                    this.dishServed = false;
                    foreach (var observer in observers)
                    {
                        observer.OnNext(changeType);
                    }
                    break;

                case "breadFinished":
                    this.breadFinished = true;
                    foreach (var observer in observers)
                    {
                        observer.OnNext(changeType);
                    }
                    break;
                    
                default:
                    break;
            }
        }
    }
}