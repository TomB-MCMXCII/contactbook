using ContactBook.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class AdressResponse
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public AdressType Type { get; set; }
    }
}