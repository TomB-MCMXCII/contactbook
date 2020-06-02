using ContactBook.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactBook.Tests
{
    public class BirthdayValidationTests
    {
        [Theory]
        [InlineData("12/8/2086", false)]
        [InlineData("4/50/2005", false)]
        [InlineData("35/12/1992", false)]
        public void ValidateBirthday_ShouldNotValidateBadDates(string birthday, bool expected)
        {
            var validation = new ValidationServices();
            var actual = validation.ValidateBirthday(birthday);
            Assert.False(actual);
        }
        [Theory]
        [InlineData("12/8/2000", true)]
        [InlineData("4/8/2005", true)]
        [InlineData("22.12.1992", true)]
        public void ValidateBirthday_ShouldValidateGoodDates(string birthday, bool expected)
        {
            var validation = new ValidationServices();
            var actual = validation.ValidateBirthday(birthday);
            Assert.True(actual);
        }
    }
}
