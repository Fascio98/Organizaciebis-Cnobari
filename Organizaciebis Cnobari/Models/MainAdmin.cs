using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Models
{
    public class MainAdmin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "საჭირო ველი")]
        public string Password { get; set; }
    }
}
