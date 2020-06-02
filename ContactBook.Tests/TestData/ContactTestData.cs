using ContactBook.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Tests.TestData
{
    public class ContactTestData
    {
        static public Contact GetContact()
        {
            var adress = new ContactAdress()
            {
                Street = "Brivibas iela",
                HouseNumber = "132",
                City = "Riga",
                Type = AdressType.Home
            };
            var email1 = new ContactEmail()
            {
                Email = "john.wood@yahoo.com",
                Type = EmailType.Work
            };
            var email2 = new ContactEmail()
            {
                Email = "woody@inbox.com",
                Type = EmailType.Work
            };
            var phone = new ContactPhone()
            {
                PhoneNumber = "23156758",
                Type = PhoneType.Work
            };
            var phone2 = new ContactPhone()
            {
                PhoneNumber = "26784567",
                Type = PhoneType.MobilePhone
            };
            var adresses = new List<ContactAdress>();
            var emails = new List<ContactEmail>();
            var phones = new List<ContactPhone>();
            adresses.Add(adress);
            emails.Add(email1);
            emails.Add(email2);
            phones.Add(phone);
            phones.Add(phone2);
            var contact = new Contact()
            {
                Name = "John",
                LastName = "Woodhill",
                Company = "Latvijas balzams",
                Notes = "A guy I met in a pub",
                DateOfBirth = "12-8-1974",
                Adresses = adresses,
                Phones = phones,
                Emails = emails
            };
            return contact;
        }
    }
}
