using Controller;
using Shared;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Restaurant {

	public class Restaurant : IRestaurant  {

        private IKitchen kitchen;
        private IRoom room;
        private DAO dao;
        private RoomManager RoomManager;
        



        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static bool exitFlag = false;

        public Restaurant()
        {
            


            RoomManager = new RoomManager();

            myTimer.Tick += new EventHandler(RoomManager.onTick);


            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 3000;
            myTimer.Start();

            // Runs the timer, and raises the event.
            while (exitFlag == false)
            {
                // Processes all the events in the queue.
                Application.DoEvents();
            }
        }

        private static void TimerEventProcessor1(Object myObject, EventArgs myEventArgs)
        {
            //myTimer.Stop();
            Console.WriteLine("Test1");

        }
        private static void TimerEventProcessor2(Object myObject, EventArgs myEventArgs)
        {
            Console.WriteLine("Test2");
            Tuple<string, int> toto = new Tuple<string, int>("a", 1);
        }
    }

}
