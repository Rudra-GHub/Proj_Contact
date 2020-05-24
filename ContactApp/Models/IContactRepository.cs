using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
     public interface IContactRepository
    {
        Task Add(Contact contact);
        Task Update(Contact contact);
        Task Delete(int id);
        Task<Contact> GetContact(int id);
        Task<IEnumerable<Contact>> GetContacts();
    }
}
