using System.Web.Http.Results;
using WebApiValidation.Controllers;
using WebApiValidation.Models;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    class CustomerValidateControllerTest
    {
        [TestCase()]
        public void TestPut_Ok()
        {
            var model = new CustomerValidateObject
            {
                Id = 0,
                Surname = string.Empty,
                Forename = null
            };

            var controller= new CustomerValidateController();
            var actionResult = controller.Post(model) as OkResult;
            Assert.IsNotNull(actionResult);
        }
    }
}
