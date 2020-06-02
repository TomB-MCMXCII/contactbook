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
    public class AdressServices
    {
        public async Task<bool> Update(ContactAdress adress, int contactId, int adressId)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var entity = ctx.Contacts
                    .IncludeFilter(x => x.Adresses.Where(z => z.Id == adressId))
                    .Single(x => x.Id == contactId);
                if (entity.Adresses.Count == 0)
                    return false;
                ctx.Adresses.RemoveRange(entity.Adresses);
                ctx.Adresses.Add(new ContactAdress
                {
                    ContactId = contactId,
                    Street = adress.Street,
                    HouseNumber = adress.HouseNumber,
                    City = adress.City,
                    Type = adress.Type,
                    lat = adress.lat,
                    lng = adress.lng
                });
                await ctx.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Add(ContactAdress adress, int contactId)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var entity = ctx.Contacts
                    .IncludeFilter(x => x.Adresses)
                    .Single(x => x.Id == contactId);
                if (entity == null)
                    return false;
                ctx.Adresses.Add(new ContactAdress
                {
                    ContactId = contactId,
                    Street = adress.Street,
                    HouseNumber = adress.HouseNumber,
                    City = adress.City,
                    Type = adress.Type,
                    lat = adress.lat,
                    lng = adress.lng
                });
                await ctx.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ContactBookDbContext())
            {
                var adressToDelete = ctx.Adresses.Find(id);
                if (adressToDelete == null)
                    return false;
                ctx.Adresses.Remove(adressToDelete);
                await ctx.SaveChangesAsync();
            }
            return true;
        }
    }
}
