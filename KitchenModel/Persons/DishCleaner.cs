using Model;
using Shared.Model;
using System;
using System.Drawing;

public class DishCleaner : KitchenPersonnel
{
    public IAction GetAction()
    {
        throw new NotImplementedException();
    }

    public IKitchen GetKitchen()
    {
        throw new NotImplementedException();
    }

    public void Move(Point position)
    {
        throw new NotImplementedException();
    }

    Point IPersonnel.GetPosition()
    {
        throw new NotImplementedException();
    }
}
