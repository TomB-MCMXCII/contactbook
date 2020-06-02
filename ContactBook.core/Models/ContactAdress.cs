using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core
{
    public class ContactAdress
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public AdressType Type { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public virtual Contact contact { get; set; }
        
        
    }
    public enum AdressType
    {
        Home ,
        Work ,
    }
}

