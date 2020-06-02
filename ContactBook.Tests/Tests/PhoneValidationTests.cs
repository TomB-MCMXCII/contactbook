using ContactBook.Controllers;
using ContactBook.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactBook.Tests
{
    public class PhoneValidationTests
    {
        [Fact]
        public void ValidatePhones_ShouldNotValidateBadPhones()
        {
            var validation = new ValidationServices();
            var phone = new ContactPhone();
            var phone1 = new ContactPhone();
            var phone2 = new ContactPhone();
            phone.PhoneNumber = "34618276";
            phone1.PhoneNumber = "534327";
            phone2.PhoneNumber = "90898908934276";
            List <ContactPhone> phones = new List<ContactPhone>();
            phones.Add(phone);
            phones.Add(phone1);
            phones.Add(phone2);
            var expected = validation.ValidatePhones(phones);
            Assert.False(expected);
        }
        [Fact]
        public void ValidatePhones_ShouldNotValidateOneBadPhone()
        {
            var validation = new ValidationServices();
            var phone = new ContactPhone();
            var phone1 = new ContactPhone();
            var phone2 = new ContactPhone();
            phone.PhoneNumber = "34618276";
            phone.Type = PhoneType.Home;
            phone1.PhoneNumber = "23432754";
            phone1.Type = PhoneType.MobilePhone;
            phone2.PhoneNumber = "60898908";
            phone2.Type = PhoneType.Work;
            var phones = new List<ContactPhone>();
            phones.Add(phone);
            phones.Add(phone1);
            phones.Add(phone2);
            var expected = validation.ValidatePhones(phones);
            Assert.False(expected);
        }
        [Fact]
        public void ValidatePhones_ShouldValidateGoodPhones()
        {
            var validation = new ValidationServices();
            var phone = new ContactPhone();
            var phone1 = new ContactPhone();
            var phone2 = new ContactPhone();
            phone.PhoneNumber = "64618276";
            phone.Type = PhoneType.Home;
            phone1.PhoneNumber = "23432754";
            phone1.Type = PhoneType.MobilePhone;
            phone2.PhoneNumber = "60898908";
            phone2.Type = PhoneType.Work;
            var phones = new List<ContactPhone>();
            phones.Add(phone);
            phones.Add(phone1);
            phones.Add(phone2);
            var expected = validation.ValidatePhones(phones);
            Assert.True(expected);
        }

        [Fact]
        public void ValidatePhones_ShouldValidateEmptyPhones()
        {
            var validation = new ValidationServices();
            var phone = new ContactPhone();
            var phone1 = new ContactPhone();
            var phone2 = new ContactPhone();
            phone.PhoneNumber = "";            
            phone1.PhoneNumber = "";
            phone2.PhoneNumber = "";
            var phones = new List<ContactPhone>();
            phones.Add(phone);
            phones.Add(phone1);
            phones.Add(phone2);
            var expected = validation.ValidatePhones(phones);
            Assert.True(expected);
        }
    }
}
