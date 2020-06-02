using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core
{
    
    public class ContactPhone
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
        public virtual Contact contact { get; set; }
    }
    public enum PhoneType
    {
         Home,
         Work,
         MobilePhone
    }
}

