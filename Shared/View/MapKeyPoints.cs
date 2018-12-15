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
                        { MapPosition.CLIENT, new Point(781, 497) },
                        { MapPosition.BUTLER, new Point(726, 461) },
                        { MapPosition.CHEF, new Point(415,630) },
                        { MapPosition.PARTYCHEF, new Point(283,580) },
                        { MapPosition.KITCHENCLERK, new Point(155,635) },
                        { MapPosition.DISHCLEANER, new Point(569, 482) },
                        { MapPosition.HEADWAITER, new Point(410, 387) },
                        { MapPosition.TABLE1, new Point(26, 27) }
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
