using Shared.Model;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class PersonnelDBEntry
    {
        [Key]
        public PersonnelType PersonnelType { get; set; }
        public int Quantity { get; set; }

        public PersonnelDBEntry()
        {
        }

        public PersonnelDBEntry(PersonnelType personnelType, int quantity)
        {
            PersonnelType = personnelType;
            Quantity = quantity;
        }
    }
}