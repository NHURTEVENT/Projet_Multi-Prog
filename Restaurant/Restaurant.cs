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
        private List<IClient> ClientList;
        private RoomManager RoomManager;




        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static bool exitFlag = false;

        public Restaurant()
        {

            ClientList = new List<IClient>();
            ClientList.Add(ClientFactory.CreateEatingClient());
            ClientList.Add(ClientFactory.CreateClient());


            // TODO Instancier des personnes !
            //private IPerson = new





            RoomManager = new RoomManager(ClientList);

            myTimer.Tick += new EventHandler(RoomManager.onTick);

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
            
        }
    }

}
