using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ContactApp.Models
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext db = new ContactDbContext();
        public async Task Add(Contact contact)
        {
           
            db.Contacts.Add(contact);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Contact> GetContact(int id)
        {
            try
            {
                Contact contact = await db.Contacts.FindAsync(id);
                if (contact == null)
                {
                    return null;
                }
                return contact;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Contact>> GetContacts()
        {
           
            try
            {
                var contacts = await db.Contacts.ToListAsync();
                return contacts.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Contact contact)
        {
            try
            {
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                Contact contact = await db.Contacts.FindAsync(id);
                db.Contacts.Remove(contact);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.Id == id) > 0;
        }

    }
}