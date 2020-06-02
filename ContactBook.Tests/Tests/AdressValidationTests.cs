using ContactBook.Controllers;
using ContactBook.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactBook.Tests.Tests
{
    public class AdressValidationTests
    {
        [Fact]
        public void ValidateAdress_ShouldNotValidateBadAdress()
        {
            var validation = new ValidationServices();
            var adress = new ContactAdress()
            {
                Street = "Zemg",
                City = "",
                HouseNumber = "43"
                
            };
            var adress1 = new ContactAdress();
            var adress2 = new ContactAdress();
           
            var adresses = new List<ContactAdress>();
            adresses.Add(adress);
            adresses.Add(adress1);
            adresses.Add(adress2);
            var expected = validation.ValidateAdress(adresses);
            Assert.False(expected);
        }
    }
}
