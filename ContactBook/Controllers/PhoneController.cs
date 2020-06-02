using ContactBook.core;
using ContactBook.services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ContactBook.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PhoneController : BaseApiController
    {
        PhoneServices service = new PhoneServices();
        ValidationServices validation = new ValidationServices();

        [HttpPost]
        [Route("api/contacts/phone")]
        public async Task<IHttpActionResult> Update(ContactPhone phone)
        {
            var phones = new List<ContactPhone>();
            phones.Add(phone);
            if (!validation.ValidatePhones(phones))
            {
                return Conflict();
            }
            var result = await service.Update(phone, phone.ContactId, phone.Id);
            if (!result)
                return NotFound();
            else
                return Ok();
        }
        [HttpPut]
        [Route("api/contacts/phone")]
        public async Task<IHttpActionResult> Add(ContactPhone phone, int contactId)
        {
            var phones = new List<ContactPhone>();
            phones.Add(phone);
            if (!validation.ValidatePhones(phones))
            {
                return Ok();
            }
            var result =  await service.Add(phone, contactId);
            if (!result)
                return NotFound();
            return Ok();
        }
        [HttpDelete]
        [Route("api/contacts/phone")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
