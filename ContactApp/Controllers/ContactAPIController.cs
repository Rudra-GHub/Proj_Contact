using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactApp.Controllers
{
    public class ContactAPIController : ApiController
    {
        private readonly IContactRepository _iContactRepository = new ContactRepository();

        [HttpGet]
        [Route("api/Contacts/Get")]
        public List<Contact> Get()
        {
            return _iContactRepository.GetContacts();
        }

        [HttpPost]
        [Route("api/Contacts/Create")]
        public async Task CreateAsync([FromBody]Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _iContactRepository.Add(contact);
            }
        }

        [HttpGet]
        [Route("api/Contacts/Details/{id}")]
        public async Task<Contact> Details(int id)
        {
            var result = await _iContactRepository.GetContact(id);
            return result;
        }

        [HttpPut]
        [Route("api/Contacts/Edit")]
        public bool EditAsync([FromBody]Contact contact)
        {
            if (ModelState.IsValid)
            {
                return _iContactRepository.Update(contact);
            }
            return false;
        }

        [HttpDelete]
        [Route("api/Contacts/Delete/{id}")]
        public async Task DeleteConfirmedAsync(int id)
        {
            await _iContactRepository.Delete(id);
        }
    }
}
