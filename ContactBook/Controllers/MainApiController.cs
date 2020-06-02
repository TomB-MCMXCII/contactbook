using ContactBook.core;
using ContactBook.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ContactBook.Models;
using Newtonsoft.Json;
using System.IO;
using System.Web.Http.Cors;

namespace ContactBook.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MainApiController : ApiController
    {
        ContactServices contactService = new ContactServices();
        BaseApiController convert = new BaseApiController();
        ValidationServices validation = new ValidationServices();

       [HttpPut]
       [Route("api/contacts")]
       public async Task<IHttpActionResult> AddContact(Contact contact)
        {
            if (!validation.IsValid(contact))
            {
                return Conflict();
            }
            var result = await contactService.Add(contact);
           if(!result.Succeded)
            {
                return Conflict();
            }
            contact.Id = result.Id;
                return Created(string.Empty, contact);
            
        }
        [HttpDelete]
        [Route("api/contacts/")]
        public async Task<IHttpActionResult> DeleteById(int id)
        {
            var result = await contactService.DeleteById(id);
            if (!result)
                return NotFound();
            else
                return Ok();
        }
        [HttpPost]
        [Route("api/contacts/")]
        public async Task<IHttpActionResult> UpdateById(Contact contactUpdated)
        {
            var contact = await contactService.GetById(contactUpdated.Id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                contactUpdated.Id = contact.Id;
                await contactService.Update(contactUpdated);
                return Ok();
            }
        }
        [HttpDelete]
        [Route("api/contacts/clear")]
        public async Task<IHttpActionResult> Clear()
        {
            var result = await contactService.Clear();
            if (result.Succeded)
                return Conflict();
            else
            return Created("deleted records: ",result.Id);
        }
        [HttpGet]
        [Route("api/contacts/")]
        public async Task<IHttpActionResult> GetContacts()
        {
            var contacts = await contactService.GetAll();
            return Ok(convert.ConvertContactsFromDomain(contacts));
        }
        [HttpGet]
        [Route("api/contacts")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var contact = await contactService.GetById(id);
            if (contact == null)
                return NotFound();
            else
                return Ok(convert.ConvertContactFromDomain(contact));
        }
        [HttpGet]
        [Route("api/contacts/search/")]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            var contacts = await contactService.GetByName(name);
            if (contacts.Count == 0)
            {
                return NotFound();
            }
            else
            return Ok(convert.ConvertContactsFromDomain(contacts));
        }
        [HttpGet]
        [Route("api/contacts/search/")]
        public async Task<IHttpActionResult> GetByLastName(string lastName)
        {
            var contacts = await contactService.GetByLastName(lastName);
            if (contacts.Count == 0)
            {
                return NotFound();
            }
            else
            return Ok(convert.ConvertContactsFromDomain(contacts));
        }
        [HttpGet]
        [Route("api/contacts/search/")]
        public async Task< IHttpActionResult> GetByCompany(string company)
        {
            var contacts = await contactService.GetByCompany(company);
            if (contacts.Count == 0)
            {
                return NotFound();
            }
            else
            return Ok(convert.ConvertContactsFromDomain(contacts));
        }       
        [HttpGet]
        [Route("api/contacts/search/")]
        public async Task<IHttpActionResult> GetByPhone(string phone)
        {
            var contact = await contactService.GetByPhone(phone);
            if (contact == null)
            {
                return NotFound();
            }
            else
                return Ok(convert.ConvertContactFromDomain(contact));
        }
        [HttpGet]
        [Route("api/contacts/search/")]
        public async Task<IHttpActionResult> GetByEmail(string email)
        {
            var contact = await contactService.GetByEmail(email);
            if (contact == null)
            {
                return NotFound();
            }
            else
            return Ok(convert.ConvertContactFromDomain(contact));
        }
        
    }
}
