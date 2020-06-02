using ContactBook.core;
using ContactBook.data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace ContactBook.services
{
    public class PhoneServices
    { 
        public async Task<bool> Update(ContactPhone phone,int contactId, int phoneId)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var entity = ctx.Contacts
                    .IncludeFilter(x => x.Phones.Where(z => z.Id == phoneId))
                    .Single(x => x.Id == contactId);
                if (entity.Phones.Count == 0)
                    return false;
                ctx.Phones.RemoveRange(entity.Phones);
                ctx.Phones.Add(new ContactPhone
                {
                    ContactId = contactId,
                    PhoneNumber = phone.PhoneNumber,
                    Type = phone.Type,                    
                });                
                await ctx.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Add(ContactPhone phone,int contactId)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var entity = ctx.Contacts
                    .IncludeFilter(x => x.Phones)
                    .Single(x => x.Id == contactId);
                if (entity == null)
                    return false;
                ctx.Phones.Add(new ContactPhone
                {
                    ContactId = contactId,
                    PhoneNumber = phone.PhoneNumber,
                    Type = phone.Type
                });
                await ctx.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using(var ctx = new ContactBookDbContext())
            {
                var phoneToDelete = ctx.Phones.Find(id);
                if (phoneToDelete == null)
                    return false;
                ctx.Phones.Remove(phoneToDelete);
                await ctx.SaveChangesAsync();
            }
            return true;
        }
    }
}
