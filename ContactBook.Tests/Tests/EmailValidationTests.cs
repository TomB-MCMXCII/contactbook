using ContactBook.Controllers;
using ContactBook.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactBook.Tests
{
    public class EmailValidationTests
    {
        [Fact]
        public void ValidateEmail_ShouldNotValidateBadEmails()
        {
            var validation = new ValidationServices();
            var email = new ContactEmail();
            var email1 = new ContactEmail();
            var email2 = new ContactEmail();
            email.Email = "email@lv";
            email1.Email = ".haha.lv";
            email2.Email = "raaaaaaa";
            var emails = new List<ContactEmail>();
            emails.Add(email);
            emails.Add(email1);
            emails.Add(email2);
            var expected = validation.ValidateEmail(emails);
            Assert.False(expected);
        }
        
        //[Fact]
        //public void ValidateEmail_ShouldNotValidateThreeBadEmails()
        //{
        //    MainApiController controller = new MainApiController();
        //    ContactEmail email = new ContactEmail();
        //    email.emailA = "email@lv";
        //    email.emailB = ".yeha.lv";
        //    email.emailC = "@hshslv";
        //    bool expected = controller.ValidateEmail(email);
        //    Assert.False(expected);
        //}
        //[Fact]
        //public void ValidateEmail_ShouldValidateThreeEmptyEmails()
        //{
        //    MainApiController controller = new MainApiController();
        //    ContactEmail email = new ContactEmail();
        //    email.emailA = "";
        //    email.emailB = "";
        //    email.emailC = "";
        //    bool expected = controller.ValidateEmail(email);
        //    Assert.True(expected);
        //}
        //[Fact]
        //public void ValidateEmail_ShouldValidateOneGoodEmail()
        //{
        //    MainApiController controller = new MainApiController();
        //    ContactEmail email = new ContactEmail();
        //    email.emailA = "@yahoo.lv";
        //    email.emailB = "";
        //    email.emailC = "";
        //    bool expected = controller.ValidateEmail(email);
        //    Assert.True(expected);
        //}

        //[Fact]
        //public void ValidateEmail_ShouldValidateTwoGoodEmails()
        //{
        //    MainApiController controller = new MainApiController();
        //    ContactEmail email = new ContactEmail();
        //    email.emailA = "sfdff@inbox.lv";
        //    email.emailB = "";
        //    email.emailC = "dsada@yah.lv";
        //    bool expected = controller.ValidateEmail(email);
        //    Assert.True(expected);
        //}



    }
}
