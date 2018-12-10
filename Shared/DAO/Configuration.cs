using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public sealed class Configuration
    {
        /*
        public static Configuration INSTANCE;
            
        private Configuration()
        {

        }

        public static Configuration Instance
        {
            get
            {
                if(INSTANCE == null)
                {
                    INSTANCE = DAO.Instance.getConfig();
                }
                return INSTANCE;
            }
        }*/

        public RoomConfiguration RoomConfig { get; set; }
        public KitchenConfiguration KitchenConfig { get; set; }

        public Configuration(RoomConfiguration roomConfig, KitchenConfiguration kitchenConfig)
        {
            RoomConfig = roomConfig;
            KitchenConfig = kitchenConfig;
        }







        //for each item in RoomConfig.tableEntries call factory to create the tables
        /*
        int nb_tables;
        int nb_2tables;
        int nb_4tables;
        int nb_6tables;
        int nb_8tables;
        int nb_10tables;
        */

        //for each item in RoomConfig.PersonnelEntries call factory to create Personnel
        /*
        int nb_Butler;
        int nb_Waiters;
        int nb_HeadWaiters;
        int nb_RoomClerks;
        */

        //for each item in RoomConfig.ItemEntries switch case on ItemType and set right property of Items 
        /*
        int nb_Flat_Plates;
        int nb_Soup_Plates;
        int nb_Dessert_Plates;
        int nb_Entree_Plates;
        int nb_Round_Glasses;
        int nb_Normal_Glasses;
        int nb_Thin_Glasses;
        int nb_Table_Clothes;
        int nb_Water_Bottles;
        int nb_Bread_Baskets;
        */

        //for each UtensilEntry 
        /*
        int nb_Cooking_Fires;
        int nb_Saucepans;
        int nb_Pans;
        int nb_WoodenSpoons;
        int nb_Blenders;
        int nb_Salad_Bowls;
        int nb_Auto_Cooks;
        int nb_Juicers;
        int nb_Sieves;
        int nb_Funnels;
        int nb_Kitchen_Knives;
        int nb_Fridges;
        int nb_Sinks;
        */

        /*
        int nb_KitchenClerks;
        int nb_KitchenPartyChefs;
        int nb_KitchenChefs;
        int nb_DishCleaners;
        */

        /*
        int nb_lave_vaisselle;
        int nb_lave_linge;
        */
    }
}
