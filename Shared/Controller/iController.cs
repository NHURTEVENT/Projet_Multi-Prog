using System;

namespace Shared
{
    public interface IController
    {
        IRestaurant GetRestaurant();
        IRoomController GetRoomController();
        IKitchenController GetKitchenController();
        void Ticked();

    }
}
