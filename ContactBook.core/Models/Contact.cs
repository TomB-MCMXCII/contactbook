using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core
{
    public class Contact 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Notes { get; set; }
        public string DateOfBirth { get; set; }
        public virtual ICollection<ContactAdress> Adresses { get; set; }
        public virtual ICollection<ContactPhone> Phones { get; set; }
        public virtual ICollection<ContactEmail> Emails { get; set; }
    }
}
