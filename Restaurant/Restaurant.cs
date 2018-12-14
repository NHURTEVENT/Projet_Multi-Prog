using Controller;
using Shared;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RoomView;

namespace Restaurant {

	public class Restaurant : IRestaurant  {

        private IKitchen kitchen;
        private IRoom room;
        private DAO dao;
        private RoomManager RoomManager;
        

        static Timer myTimer = new Timer();
        static bool exitFlag = false;

        public Restaurant()
        {

            Configuration conf = DAO.Instance.getConfig();
            RoomManager = new RoomManager(conf);

            myTimer.Tick += new EventHandler(RoomManager.onTick);


            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 5000;
            myTimer.Start();
            Application.Run(new FormView(myTimer, RoomManager));
            

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
