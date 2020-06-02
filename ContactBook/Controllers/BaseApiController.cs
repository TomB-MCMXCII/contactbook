using ContactBook.core;
using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactBook.Controllers
{
    public class BaseApiController : ApiController
    {
        public ContactResponse ConvertContactFromDomain(Contact contact)
        {
            return new ContactResponse
            {
                Id = contact.Id,
                Name = contact.Name,
                LastName = contact.LastName,
                Company = contact.Company,
                Notes = contact.Notes,
                DateOfBirth = contact.DateOfBirth,
                Phones = ConvertPhoneFromDomain(contact.Phones),
                Emails = ConvertEmailFromDomain(contact.Emails),
                Adresses = ConvertAdressFromDomain(contact.Adresses)
            };
        }
        public ICollection<ContactResponse> ConvertContactsFromDomain(ICollection<Contact> contactsToConvert)
        {
            List<ContactResponse> contactResponses = new List<ContactResponse>();
            foreach (var c in contactsToConvert)
            {
                ContactResponse contact = new ContactResponse();
                contact.Id = c.Id;
                contact.Name = c.Name;
                contact.LastName = c.LastName;
                contact.Company = c.Company;
                contact.Notes = c.Notes;
                contact.DateOfBirth = c.DateOfBirth;
                contact.Phones = ConvertPhoneFromDomain(c.Phones);
                contact.Emails = ConvertEmailFromDomain(c.Emails);
                contact.Adresses = ConvertAdressFromDomain(c.Adresses);
                contactResponses.Add(contact);
            }
            return contactResponses;
        }
        public ICollection<PhoneResponse> ConvertPhoneFromDomain(ICollection<ContactPhone> phonesToConvert)
        {
            List<PhoneResponse> phoneResponse = new List<PhoneResponse>();
            foreach (var p in phonesToConvert)
            {
                PhoneResponse phone = new PhoneResponse();
                phone.Id = p.Id;
                phone.ContactId = p.ContactId;
                phone.PhoneNumber = p.PhoneNumber;
                phone.Type = p.Type;
                phoneResponse.Add(phone);
            }
            return phoneResponse;          
        }
        public ICollection<EmailResponse> ConvertEmailFromDomain(ICollection<ContactEmail> emailsToConvert)
        {
            List<EmailResponse> emailResponse = new List<EmailResponse>();
            foreach (var e in emailsToConvert)
            {
                EmailResponse email = new EmailResponse();
                email.Id = e.Id;
                email.ContactId = e.ContactId;
                email.Email = e.Email;
                email.Type = e.Type;
                emailResponse.Add(email);
            }
            return emailResponse;
        }
        public ICollection<AdressResponse> ConvertAdressFromDomain(ICollection<ContactAdress> adressesToConvert)
        {
            List<AdressResponse> adressResponse = new List<AdressResponse>();
            foreach (var a in adressesToConvert)
            {
                AdressResponse adress = new AdressResponse();
                adress.Id = a.Id;
                adress.ContactId = a.ContactId;
                adress.Street = a.Street;
                adress.HouseNumber = a.HouseNumber;
                adress.City = a.City;
                adress.Type = a.Type;
                adress.lat = a.lat;
                adress.lng = a.lng;
                adressResponse.Add(adress);
            }
            return adressResponse;
        }
        public EmailResponse ConvertEmailFromRequest(ContactEmail email)
        {
            return new EmailResponse 
            {
                Email = email.Email,
                Type = email.Type
            };        
        }
        public PhoneResponse ConvertPhoneFromRequest(ContactPhone phone)
        {
            return new PhoneResponse
            {
                PhoneNumber = phone.PhoneNumber,
                Type = phone.Type
            };
        }
        public AdressResponse ConvertAdressFromRequest(ContactAdress adress)
        {
            return new AdressResponse
            {
                Street = adress.Street,
                HouseNumber = adress.HouseNumber,
                City = adress.City,
                Type = adress.Type
            };
        }
    }

    
}
