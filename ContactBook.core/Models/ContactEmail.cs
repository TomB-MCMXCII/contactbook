using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core
{
    public class ContactEmail
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Email { get; set; }
        public EmailType Type { get; set; }
        public virtual Contact contact { get; set; }

    }
    public enum EmailType
    {
        Personal,
        Work
    }
}

