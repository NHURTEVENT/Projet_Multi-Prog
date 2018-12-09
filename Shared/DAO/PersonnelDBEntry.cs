using Shared.Model;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class PersonnelDBEntry
    {
        [Key]
        PersonnelType PersonnelType { get; set; }
        int Quantity { get; set; }
    }
}