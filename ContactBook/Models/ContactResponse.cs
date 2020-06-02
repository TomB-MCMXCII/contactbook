using ContactBook.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class ContactResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Notes { get; set; }
        public string DateOfBirth { get; set; }
        public ICollection<PhoneResponse> Phones { get; set; }
        public ICollection<EmailResponse> Emails { get; set; }
        public ICollection<AdressResponse> Adresses { get; set; }
    }
}