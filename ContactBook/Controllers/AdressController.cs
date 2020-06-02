using ContactBook.core;
using ContactBook.services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ContactBook.Controllers
{
    public class AdressController : ApiController
    {
        AdressServices service = new AdressServices();
        ValidationServices validation = new ValidationServices();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/contacts/adress")]
        public async Task<IHttpActionResult> Update(ContactAdress adress)
        {
            var adresses = new List<ContactAdress>();
            adresses.Add(adress);
            validation.ValidateAdress(adresses);
            if (!validation.ValidateAdress(adresses))
            {
                return Conflict();
            }
            var result = await service.Update(adress, adress.ContactId, adress.Id);
            if (!result)
                return NotFound();
            else
                return Ok();
        }
        [HttpPut]
        [Route("api/contacts/adress")]
        public async Task<IHttpActionResult> Add(ContactAdress adress, int contactId)
        {
            var adresses = new List<ContactAdress>();
            adresses.Add(adress);
            
            if (!validation.ValidateAdress(adresses))
            {
                return Conflict();
            }
            var result = await service.Add(adress, contactId);
            if (!result)
                return NotFound();
            return Ok();
        }
        [HttpDelete]
        [Route("api/contacts/adress")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
