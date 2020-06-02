using ContactBook.core;
using ContactBook.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace ContactBook.services.Services
{
    public class EmailServices
    {
        public async Task<bool> Update(ContactEmail email, int contactId, int emailId)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var entity = ctx.Contacts
                    .IncludeFilter(x => x.Emails.Where(z => z.Id == emailId))
                    .Single(x => x.Id == contactId);
                if (entity.Emails.Count == 0)
                    return false;
                ctx.Emails.RemoveRange(entity.Emails);
                ctx.Emails.Add(new ContactEmail
                {
                    ContactId = contactId,
                    Email = email.Email,
                    Type = email.Type,
                });
                await ctx.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Add(ContactEmail email, int contactId)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var entity = ctx.Contacts
                    .IncludeFilter(x => x.Emails)
                    .Single(x => x.Id == contactId);
                if (entity == null)
                    return false;
                ctx.Emails.Add(new ContactEmail
                {
                    ContactId = contactId,
                    Email = email.Email,
                    Type = email.Type
                });
                await ctx.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var emailToDelete = ctx.Emails.Find(id);
                if (emailToDelete == null)
                    return false;
                ctx.Emails.Remove(emailToDelete);
                await ctx.SaveChangesAsync();
            }
            return true;
        }
    }
}
