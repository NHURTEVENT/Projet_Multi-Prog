using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoomModel.Persons
{
    class Person : IPerson
    {
        public Person(int remainingTicks, string currentAction)
        {
            this.remainingTicks = remainingTicks;
            this.currentAction = currentAction;
        }

        public int remainingTicks { get; set; }
        public string currentAction { get; set; }

        public Point GetPosition()
        {
            throw new NotImplementedException();
        }

        public void Move(Point position)
        {
            throw new NotImplementedException();
        }

        public void setTask(string task)
        {
            throw new NotImplementedException();
        }
    }
}
