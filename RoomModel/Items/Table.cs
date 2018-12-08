using Shared;
using System;
using System.Threading;

namespace Model
{
    public class Table : ITable
    {
        public string squareNumber { get; set; }
        public string row { get; set; }
        public string position { get; set; }
        public int size { get; set; }
        public bool available { get; set; }

        public Table()
        {
            this.available = true;
            this.size = 4;

        }


        public void IsOccuped()
        {

        }


    }
}