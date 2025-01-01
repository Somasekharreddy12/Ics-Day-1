using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MVC_ASSIGNMENT_1.Models;

namespace MVC_ASSIGNMENT_1.Repository
{
    public class ContactRepository : IContactRepository
    {
        ContactContext db;
        public ContactRepository()
        {
            db = new ContactContext();

        }
        public async Task<List<Contact>> GetAllAsync()
        {
            return await db.Contacts.ToListAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            db.Contacts.Add(contact);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long Id)
        {
            var contact = await db.Contacts.FindAsync(Id);
            if (contact != null)
            {
                db.Contacts.Remove(contact);
                await db.SaveChangesAsync();
            }
        }

    }
    
}