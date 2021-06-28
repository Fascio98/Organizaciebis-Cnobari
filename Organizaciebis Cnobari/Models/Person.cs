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
        [Required(ErrorMessage = "შეიყვანეთ სახელი")]
        public string Name { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ გვარი")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ პირადი ნომერი")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "ველის სიგრძე უნდა იყოს 11-ის ტოლი!")]
        public string PersonalID { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ დაბადებისდღე")]
        [DataType(DataType.Date)]
        [Display(Name ="1")]
        public DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ ტელეფონის ნომერი")]
        public string TelephoneNumbers { get; set; }
        [Required(ErrorMessage = "ატვირთეთ ფოტო")]
        public string Photo { get; set; }

    }
}
