using ContactBook.core;
using ContactBook.data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace ContactBook.services
{
    public class ContactServices 
    { 
        public async Task<ServiceResult> Add(Contact contact)
        {
            using (var ctx = new ContactBookDbContext())
            {

                ctx.Contacts.Add(contact);
                await ctx.SaveChangesAsync();
                return new ServiceResult(true,contact.Id);

            }
        }
        public async Task Update(Contact contact)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var entity = ctx.Contacts
                    .Include(x => x.Adresses)
                    .Include(x => x.Emails)
                    .Include(x => x.Phones)
                    .Single(x => x.Id == contact.Id);
                ctx.Entry(entity).CurrentValues.SetValues(contact);
                await ctx.SaveChangesAsync();
            }
        }
        public async Task<bool> DeleteById(int id)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var contact = ctx.Contacts.Find(id);
                if (contact == null)
                {
                    return false;
                }
                else
                {
                    ctx.Contacts.Remove(contact);
                    await ctx.SaveChangesAsync();
                    return true;
                }
            }   
        }
        public async Task<ICollection<Contact>> GetAll()
        {
            using (var ctx = new ContactBookDbContext())
            {
                var contacts = await ctx.Contacts.Include(x => x.Adresses)
                    .Include(x => x.Emails)
                    .Include(x => x.Phones)
                    .ToListAsync();
                return contacts;
            }
        }
        public async Task<ServiceResult> Clear()
        {
            using (var ctx = new ContactBookDbContext())
            {
                var records = ctx.Contacts.ToList();
                ctx.Contacts.RemoveRange(records);
                var list = ctx.Contacts.ToList();
                await ctx.SaveChangesAsync();
                if (list.Count > 0)
                    return new ServiceResult(false, records.Count);
                else
                    return new ServiceResult(false, records.Count);
            }
        }
        public async Task<Contact> GetById(int id)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var contact = await ctx.Contacts.Include(x => x.Adresses)
                    .Include(x => x.Emails)
                    .Include(x => x.Phones)
                    .SingleOrDefaultAsync(i => i.Id == id);
                return contact;
            }
        }
        public async  Task<ICollection<Contact>> GetByName(string name)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var contacts = await ctx.Contacts.Include(x => x.Phones)
                    .Include(x => x.Emails)
                    .Include(x => x.Adresses)
                    .Where(n => n.Name.StartsWith(name))
                    .ToListAsync();
                return contacts;
            }
        }
        public async Task<ICollection<Contact>> GetByCompany(string companyName)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var contacts = await ctx.Contacts.Include(x => x.Adresses)
                    .Include(x => x.Emails)
                    .Include(x => x.Phones)
                    .Where(n => n.Company == companyName)
                    .ToListAsync();
                return contacts;
            }
        }
        public async Task<ICollection<Contact>> GetByLastName(string lastName)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var contacts = await ctx.Contacts
                    .Include(x => x.Adresses)
                    .Include(x => x.Emails)
                    .Include(x => x.Phones)
                    .Where(n => n.LastName.StartsWith(lastName))
                    .ToListAsync();
                return contacts;
            }
        }
        public async Task<Contact> GetByEmail(string email)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var allContacts = await ctx.Contacts
                .IncludeFilter(c => c.Emails)
                .IncludeFilter(x => x.Adresses)
                .IncludeFilter(x => x.Phones)
                .FirstOrDefaultAsync();

                var contactEmail = allContacts.Emails
                    .Where(x => x.Email == email)
                    .FirstOrDefault();

                var contact = await ctx.Contacts
                    .IncludeFilter(c => c.Emails)
                    .IncludeFilter(x => x.Adresses)
                    .IncludeFilter(x => x.Phones)
                    .FirstOrDefaultAsync(x => x.Id == contactEmail.ContactId);
                return contact;
            }
        }
        public async Task<Contact> GetByPhone(string phone)
        {
            using (var ctx = new ContactBookDbContext())
            {                
                var allContacts = await ctx.Contacts
                .IncludeFilter(c => c.Emails)
                .IncludeFilter(x => x.Adresses)
                .IncludeFilter(x => x.Phones)                
                .FirstOrDefaultAsync();

                var contactPhone = allContacts.Phones
                    .Where(x => x.PhoneNumber == phone)
                    .FirstOrDefault();

                var contact = await ctx.Contacts
                    .IncludeFilter(c => c.Emails)
                    .IncludeFilter(x => x.Adresses)
                    .IncludeFilter(x => x.Phones)
                    .FirstOrDefaultAsync(x => x.Id == contactPhone.ContactId);
                return contact;
            }
        }
    }
}


