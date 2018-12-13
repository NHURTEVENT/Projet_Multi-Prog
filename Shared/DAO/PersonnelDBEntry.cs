using Shared.Model;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    /// <summary>
    /// Number of employees in the restaurant for a given personnel type
    /// </summary>
    public class PersonnelDBEntry
    {
        //Primary key, job title
        [Key]
        public PersonnelType PersonnelType { get; set; }
        //number of this type of employee working in the restaurant
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