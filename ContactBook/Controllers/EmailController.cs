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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmailController : BaseApiController
    {
        EmailServices service = new EmailServices();
        ValidationServices validation = new ValidationServices();

        [HttpPost]
        [Route("api/contacts/email")]
        public async Task<IHttpActionResult> Update(ContactEmail email)
        {
            var emails = new List<ContactEmail>();
            emails.Add(email);
            if (!validation.ValidateEmail(emails))
            {
                return Conflict();
            }
            var result = await service.Update(email, email.ContactId, email.Id);
            if (!result)
                return Conflict();
            else
                return Ok();
        }
        [HttpPut]
        [Route("api/contacts/email")]
        public async Task<IHttpActionResult> Add(ContactEmail email, int contactId)
        {
            var emails = new List<ContactEmail>();
            emails.Add(email);
            
            if (!validation.ValidateEmail(emails))
            {
                return Conflict();
            }
            var result = await service.Add(email, contactId);
            if (!result)
                return Conflict();
            return Ok();
        }
        [HttpDelete]
        [Route("api/contacts/email")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
