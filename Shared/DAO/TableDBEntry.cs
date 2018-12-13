using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared
{
    /// <summary>
    /// All relevant information about a table to initiate the simulation
    /// </summary>
    public class TableDBEntry
    {
        //Composed primary key to identify the table with its position
        //Square in which the table is
        [Key, Column(Order = 0)]
        public int Square { get; set; }
        //Row in which the table is
        [Key, Column(Order = 1)]
        public int Row { get; set; }
        //Column in which the table is
        [Key, Column(Order = 2)]
        public int Column { get; set; }

        //Number of client the table can seat
        public int Size { get; set; }

        public TableDBEntry()
        {
        }

        public TableDBEntry(int size, int square, int row, int column)
        {
            Size = size;
            Square = square;
            Row = row;
            Column = column;
        }
    }
}