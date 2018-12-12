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
            //Préparation et démarrage du thread en charge d'écouter.
            _thEcoute = new Thread(new ThreadStart(Ecouter));
            _thEcoute.Start();
        }

        public static void Ecouter()
        {
            Console.WriteLine("Attente commande . . .");

            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient serveur = new UdpClient(5035);

            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (true)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                Console.WriteLine("Le chef cuisinier vous écoute");

                //On écoute jusqu'à recevoir un message.
                byte[] data = serveur.Receive(ref client);
                Console.WriteLine("Données reçues en provenance de {0}:{1}.", client.Address, client.Port);

                //Décryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                Console.WriteLine("CONTENU DU MESSAGE : {0}\n", message);
            }
        }

}
