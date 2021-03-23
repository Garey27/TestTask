using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerCatalog.Models
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female
    }
    public enum Country
    {
        [Display(Name = "Russia")]
        Russia,
        [Display(Name = "USA")]
        USA,
        [Display(Name = "Italy")]
        Italy
    }
    public class Footballer : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeamName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Country Country { get; set; }
    }
}
