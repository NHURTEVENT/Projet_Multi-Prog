using Shared;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class RoomPersonnelFactory
    {

        //reference kept for Butlers
        private static List<IHeadWaiter> HeadWaiters = new List<IHeadWaiter>();
        //references kept for Headwaiters and Butlers
        private static List<ITable> Tables = new List<ITable>();

        public static List<ITable> createTables(List<TableDBEntry> tableEntries)
        {
            //Clears the local list
            Tables.Clear();
            //for each tableEntry create a table and add it to the local list
            tableEntries.ForEach(t => Tables.Add(new Table(t.Square, t.Row, t.Column, t.Size)));
            //return the list of newly created tables
            return Tables;
        }
        

        public static IPerson createPerson(PersonnelType personnelType)
        {
            switch (personnelType)
            {
                case PersonnelType.WAITER:
                    return new Waiter(Tables, Counter.Instance);
                case PersonnelType.ROOMCLERK:
                    return new RoomClerk();
                case PersonnelType.HEADWAITER:
                    if (Tables.Count > 0)
                    {
                        var headwaiter = new HeadWaiter(Tables);
                        HeadWaiters.Add(headwaiter);
                        return headwaiter;
                    }
                    else
                        throw new ArgumentNullException("cannot find tables for headwaiters");
                case PersonnelType.BUTLER:
                    if (Tables.Count > 0)
                    {
                        if (HeadWaiters.Count > 0)
                            return new Butler(Tables, HeadWaiters);
                        else
                            throw new ArgumentNullException("cannot find headwaiters for butlers");
                    }
                    else
                        throw new ArgumentNullException("cannot find tables for butlers");
                default:
                    throw new InvalidOperationException("cannot create personnel of type " + personnelType.ToString());
            }
        }

        public static IButler CreateButler(List<ITable> tables, List<IHeadWaiter> headWaiters)
        {
            return new Butler(tables, headWaiters);
        }

        public static IHeadWaiter CreateHeadWaiter(List<ITable> tables)
        {
            return new HeadWaiter(tables);
        }
    }
}
