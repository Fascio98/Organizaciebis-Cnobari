using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Entities
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
       // [Required(ErrorMessage = "შეიყვანეთ ")]
        [Required(ErrorMessage ="შეიყვანეთ დაბადების დღე!")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }
        [Required(ErrorMessage ="შეიყვანეთ ტელეფონის ნომერი")]
        public string TelephoneNumbers { get; set; }
        public string Photo { get; set; }
    }
}
