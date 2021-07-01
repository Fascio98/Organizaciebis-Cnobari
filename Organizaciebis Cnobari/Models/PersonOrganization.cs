using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Models
{
    public class PersonOrganization
    {
        public int Id { get; set; }
        public ICollection<Organization> MyOrganization { get; set; }
        public ICollection<Person> MyPerson { get; set; }
        public string Position { get; set; }

    }
}
