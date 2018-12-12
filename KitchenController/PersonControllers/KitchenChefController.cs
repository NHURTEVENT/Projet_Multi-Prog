using Shared;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Controller {
	public class KitchenChefController : IKitchenChefController
    {
	
        public void Cook(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void RequestUstensil(IUstensil ustensil)
        {
            throw new NotImplementedException();
        }

        public void FreeUstensil(IUstensil ustensil)
        {
            throw new NotImplementedException();
        }

        public void ManageClerk()
        {
            throw new NotImplementedException();
        }

        public static Thread _thEcoute;

        private static void Main(string[] args)
        {
            //Pr�paration et d�marrage du thread en charge d'�couter.
            _thEcoute = new Thread(new ThreadStart(Ecouter));
            _thEcoute.Start();
        }

        public static void Ecouter()
        {
            Console.WriteLine("Attente commande . . .");

            //On cr�e le serveur en lui sp�cifiant le port sur lequel il devra �couter.
            UdpClient serveur = new UdpClient(5035);

            //Cr�ation d'une boucle infinie qui aura pour t�che d'�couter.
            while (true)
            {
                //Cr�ation d'un objet IPEndPoint qui recevra les donn�es du Socket distant.
                IPEndPoint client = null;
                Console.WriteLine("Le chef cuisinier vous �coute");

                //On �coute jusqu'� recevoir un message.
                byte[] data = serveur.Receive(ref client);
                Console.WriteLine("Donn�es re�ues en provenance de {0}:{1}.", client.Address, client.Port);

                //D�cryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                Console.WriteLine("CONTENU DU MESSAGE : {0}\n", message);
            }
        }

}
