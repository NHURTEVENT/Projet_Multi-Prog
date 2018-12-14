using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public sealed class MapKeyPoints
    {
        private static MapKeyPoints INSTANCE;

        private static Dictionary<MapPosition, Point> POSITION;

        
        public static Dictionary<MapPosition, Point> positions
        {
            get
            {   
                if(POSITION == null){
                    POSITION = new Dictionary<MapPosition, Point>
                    {
                        { MapPosition.WAITER, new Point(540,95) },
                        { MapPosition.CLIENT, new Point(935,364) },
                        { MapPosition.BUTLER, new Point(880,625) },
                        { MapPosition.CHEF, new Point(415,630) },
                        { MapPosition.PARTYCHEF, new Point(283,580) },
                        { MapPosition.KITCHENCLERK, new Point(155,635) },
                        { MapPosition.DISHCLEANER, new Point(780,600) },
                        { MapPosition.HEADWAITER, new Point(30,30) },
                        { MapPosition.TABLE1, new Point(5,45) }
                    };  
            }
                return POSITION;
            }
        }

        
            //xWaiter = 540;
            //yWaiter = 95;

            //xClient = 935;
            //yClient = 364;

            //xButler = 880;
            //yButler = 625;

            //xChef = 415;
            //yChef = 630;

            //xChefP1 = 283;
            //yChefP1 = 580;

            //xChefP2 = 283;
            //yChefP2 = 650;

            //xKClurk = 155;
            //yKClurk = 635;

            //xDishCleaner = 780;
            //yDishCleaner = 600;

            //xHeadWaiter = 30;
            //yHeadWaiter = 30;
    }
}
