using Shared.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shared {
	public interface IPerson {


        string Name { get; set; }
        PersonnelType Type { get; set; }
        IAction CurrentAction { get; set; }
        Brush Color { get; set; }
        int RemainingTicks { get; set; }
        Point Position { get; set; }

        List<IAction> ActionQueue { get; set; }

        void onTick();
        void ChangeAction(IAction Action);



        Point GetPosition();
        void Move(Point position);
        //PersonType getType();

    }

}
