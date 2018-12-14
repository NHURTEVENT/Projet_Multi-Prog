using System;
using System.Threading;
public class Table {
    public int ID { get; set; }
	private int squareNumber { get; set; }
    private int row { get; set; }
    private int column { get; set; }
    private int size { get; set; }
    private Semaphore available;

    public Table(int size,int row, int column, int squareNumber)
    {
        this.size = size;
        this.row = row;
        this.column = column;
        this.squareNumber = squareNumber;
    }
}
