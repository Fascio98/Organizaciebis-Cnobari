using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        public string Name { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        [StringLength(maximumLength:50, ErrorMessage ="ველის სიგრძე არ უნდა აღემატებოდეს 50-ს!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        [StringLength(maximumLength: 500, ErrorMessage = "ველის სიგრძე არ უნდა აღემატებოდეს 500-ს!")]
        public string Activity { get; set; }
        public PersonOrganization OrganizationPerson { get; set; }
    }
}
