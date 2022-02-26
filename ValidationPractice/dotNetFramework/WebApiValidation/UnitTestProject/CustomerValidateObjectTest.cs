using System.Collections.Generic;
using WebApiValidation.Models;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    public class CustomerValidateObjectTest
    {
        [TestCase(null, null,null)]
        [TestCase(-1, null,null)]
        [TestCase(0, null,null)]
        [TestCase(1, null,null)]
        [TestCase(1, "",null)]
        [TestCase(1, null,"")]
        [TestCase(1, "","")]
        [TestCase(101, "","")]
        public void TestCustomerValidateObject_Validate_Failed(int? id , string surName, string foreName)
        {
            var model = new CustomerValidateObject
            {
                Id = id,
                Surname = surName,
                Forename = foreName
            };
            var context = new ValidationContext(model);
            Assert.IsFalse(Validator.TryValidateObject(model, context, new List<ValidationResult>()));
        }

        [TestCase(1, "Yamamoto","Satoshi")]
        [TestCase(100, "Yamamoto","Satoshi")]
        public void TestCustomerValidateObject_Validate_Success(int id , string surName, string foreName)
        {
            var model = new CustomerValidateObject
            {
                Id = id,
                Surname = surName,
                Forename = foreName
            };
            var context = new ValidationContext(model);
            Assert.IsTrue(Validator.TryValidateObject(model, context, new List<ValidationResult>()));
        }
    }
}
