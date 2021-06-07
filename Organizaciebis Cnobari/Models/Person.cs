using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        public string Name { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "ველის სიგრძე უნდა იყოს 11-ის ტოლი!")]
        public string PersonalID { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        [DataType(DataType.Date)]
        [Display(Name ="1")]
        public DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        public string TelephoneNumbers { get; set; }
    }
}
