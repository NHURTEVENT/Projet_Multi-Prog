using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared
{
    public class TableDBEntry
    {
        
        public int Size { get; set; }
        [Key, Column(Order = 0)]
        public int Square { get; set; }
        [Key, Column(Order = 1)]
        public int Row { get; set; }
        [Key, Column(Order = 2)]
        public int Column { get; set; }

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