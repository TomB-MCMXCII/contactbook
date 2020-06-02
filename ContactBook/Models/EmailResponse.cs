using ContactBook.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class EmailResponse
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Email { get; set; }
        public EmailType Type { get; set; }
    }
}