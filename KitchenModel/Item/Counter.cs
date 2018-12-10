using Shared;
using System;
using System.Net.Sockets;
using System.Text

namespace Model{

    public class Counter
    {
        private String size;
        private int maxCapacity;
        private int dishCounter = 17;

        public int getMaxCapacity()
        {
            return this.maxCapacity;
        }

        public void setMaxCapacity()
        {
            maxCapacity = 15;
        }

        public void Condition(int maxCapacity)
        {
            if (dishCounter >= maxCapacity)
            {
                bool continuer = true;

                while (continuer)
                {
                    Console.Write("\nLE nombre de plat sur le comptoir est au max ");
                    string message = Console.ReadLine();

                    //Sérialisation du message en tableau de bytes.
                    byte[] msg = Encoding.Default.GetBytes(message);

                    UdpClient udpClient = new UdpClient();

                    //La méthode Send envoie un message UDP.
                    udpClient.Send(msg, msg.Length, "127.0.0.1", 5040);

                    udpClient.Close();


                    //Console.Write("\nContinuer ? (O/N)");
                    continuer = false;
                }

            }
            else
            {
                throw new System.Exception("Not implemented");

            }

        private Dish dish;


    }
}