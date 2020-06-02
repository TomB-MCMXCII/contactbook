using ContactBook.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class PhoneResponse
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
    }
}