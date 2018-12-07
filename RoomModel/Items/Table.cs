using Shared;
using System;
using System.Threading;

namespace Model
{
    public class Table : ITable
    {
        private String squareNumber;
        private String row;
        private String position;
        private String size;
        private Semaphore available;

        public Table()
        {
        }
    }
}