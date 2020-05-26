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
           
           
            try
            {
                db.Contacts.Add(contact);
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
        public List<Contact>  GetContacts()
        {           
            try
            {
                
                var contacts =  db.Contacts.ToList();
                return contacts;
            }
            catch
            {
                throw;
            }
        }
        public bool Update(Contact contact)
        {
            try
            {
                //db.Entry(contact).State = EntityState.Modified;
                Contact contact1 = db.Contacts.Find(contact.Id);
                if (contact1 != null)
                {
                    contact1.FirstName = contact.FirstName;
                    contact1.LastName = contact.LastName;
                    contact1.Email = contact.Email;
                    contact1.PhoneNumber = contact.PhoneNumber;
                    contact1.Status = contact.Status;
                    db.SaveChanges();
                    return true;
                }
                return false;
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