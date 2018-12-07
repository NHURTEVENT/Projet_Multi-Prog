using Model;
using Shared.Model;
using System;
using System.Windows.Forms;

namespace Restaurant {
	public class Restaurant : IRestaurant  {
        private IKitchen kitchen;
        private IRoom room;
		private DAO dao;

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static bool exitFlag = false;

        public Restaurant()
        {
            RunTimer();

        }

        public void RunTimer()
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 1000;
            myTimer.Start();

            // Runs the timer, and raises the event.
            while (exitFlag == false)
            {
                // Processes all the events in the queue.
                Application.DoEvents();
            }
        }

        private static void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            //myTimer.Stop();

            // Displays a message box asking whether to continue running the timer.
            Console.WriteLine("ding, ding");
            
        }
    }

}
