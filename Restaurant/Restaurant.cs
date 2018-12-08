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

        private List<IClient> ClientList;



        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static bool exitFlag = false;

        public Restaurant()
        {

            ClientList = new List<IClient>();
            ClientList.Add(ClientFactory.CreateEatingClient("Michel"));
            ClientList.Add(ClientFactory.CreateClient());


            // TODO Instancier des personnes !
            //private IPerson = new


            RoomManager = new RoomManager(ClientList);

            myTimer.Tick += new EventHandler(RoomManager.onTick);
            //myTimer.Tick += new EventHandler(TimerEventProcessor1);
            //myTimer.Tick += new EventHandler(TimerEventProcessor2);


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

        private static void TimerEventProcessor1(Object myObject, EventArgs myEventArgs)
        {
            //myTimer.Stop();
            Console.WriteLine("Test1");

        }
        private static void TimerEventProcessor2(Object myObject, EventArgs myEventArgs)
        {
            Console.WriteLine("Test2");

        }
    }

}
