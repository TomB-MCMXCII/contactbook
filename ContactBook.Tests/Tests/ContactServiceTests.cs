using ContactBook.services;
using ContactBook.Tests.TestData;
using Xunit;

namespace ContactBook.Tests.Tests
{
   
    public class ContactServiceTests
    {
        [Fact]
        public async void ShouldAddAndRetrieveSameContact()
        {  
            var service = new ContactServices();
            var contact = ContactTestData.GetContact();
            await service.Add(contact);
            var expected = await service.GetAll();
            foreach (var ex in expected)
            {
                Assert.NotNull(ex.Id);
                Assert.Equal(ex.Name, contact.Name);
                Assert.Equal(ex.LastName, contact.LastName);
                Assert.Equal(ex.Company, contact.Company);
                Assert.Equal(ex.Notes, contact.Notes);
                Assert.Equal(ex.DateOfBirth, contact.DateOfBirth);
                foreach(var adress in ex.Adresses)
                {
                    foreach(var b in contact.Adresses)
                    {
                        Assert.NotNull(b.Id);
                        Assert.NotNull(b.ContactId);
                        Assert.Equal(adress.Street, b.Street);
                        Assert.Equal(adress.HouseNumber, b.HouseNumber);
                        Assert.Equal(adress.City, b.City);
                    }
                }
                foreach (var a in ex.Phones)
                {
                    foreach (var b in contact.Phones)
                    {
                        Assert.NotNull(b.Id);
                        Assert.NotNull(b.ContactId);
                        Assert.Equal(a.PhoneNumber, b.PhoneNumber);
                    }
                }
                foreach (var a in ex.Emails)
                {
                    foreach (var b in contact.Emails)
                    {
                        Assert.NotNull(b.Id);
                        Assert.NotNull(b.ContactId);
                        Assert.Equal(a.Email, b.Email);
                    }
                }
            }  
        }
        [Fact]
        public async void ShouldSearchByName()
        {
            var service = new ContactServices();
            await service.Add(ContactTestData.GetContact());
            var contact = ContactTestData.GetContact();
            var expected = await service.GetByName(contact.Name);
            foreach (var e in expected)
            {
                Assert.Equal(contact.Name, e.Name);
            }
        }
        [Fact]
        public async void ShouldSearchByLastName()
        {
            var service = new ContactServices();
            await service.Add(ContactTestData.GetContact());
            var contact = ContactTestData.GetContact();
            var expected = await service.GetByLastName(contact.LastName);
            foreach (var e in expected)
            {
                Assert.Equal(contact.LastName, e.LastName);
            }
        }
        [Fact]
        public async void ShouldSearchByCompany()
        {
            var service = new ContactServices();
            await service.Add(ContactTestData.GetContact());
            var contact = ContactTestData.GetContact();
            var expected = await service.GetByCompany(contact.Company);
            foreach (var e in expected)
            {
                Assert.Equal(contact.Company, e.Company);
            }
        }
        [Fact]
        public async void ShouldSearchByEmail()
        {
            var service = new ContactServices();
            await service.Add(ContactTestData.GetContact());
            var contact = ContactTestData.GetContact();
            var expected = await service.GetByEmail("john.wood@yahoo.com");
            Assert.True(expected.Emails.Count == contact.Emails.Count);
                                    
        }
        [Fact]
        public async void ShouldSearchByPhone()
        {
            var service = new ContactServices();
            await service.Add(ContactTestData.GetContact());
            var contact = ContactTestData.GetContact();
            var expected = await service.GetByPhone("23156758");
           
            Assert.True(expected.Phones.Count == contact.Phones.Count);




        }
    }
}
