using System;
namespace Shared
{

    public interface IHeadKitchenChefController
    {

        void takeOrder(IHeadWaiter headWaiter);
        void giveOrder(IKitchenChefController kitchenChefController);

    }

}
