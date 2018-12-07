using Model;
using RoomController;
using Shared.Model;
using System;
using RoomModel.Persons;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Restaurant {
	public class Restaurant : IRestaurant  {

        private List<IPerson> personList;

        // TODO Instancier des personnes !
        //private IPerson = new

        private IKitchen kitchen;
        private IRoom room;
		private DAO dao;



        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static bool exitFlag = false;

        public Restaurant()
        {

            RoomManager roomManager = new RoomManager(personList);

            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 1 seconds.
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
