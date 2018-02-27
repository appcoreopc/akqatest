using Microsoft.VisualStudio.TestTools.UnitTesting;
using AkqaDataServices.DataModel;
using NSubstitute;
using AkqaWebApi.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AkqaWebApi.Models;
using Microsoft.Extensions.Logging;

namespace AkqaWebApiTest.Controllers
{
    [TestClass]

    public class UserControllerTest : TestBase
    {
        ILogger<UserController> _logger = Substitute.For<ILogger<UserController>>();

        [TestInitializeAttribute]
        public void TestCaseInit()
        {
            // Arrange //
            InitTestCase();
        }
        
        [TestMethod]
        public void GetUserAmountOk()
        {
            var options = new DbContextOptions<AkqaDataStoreContext>();         
            var context = Substitute.For<FakeAkqaDbContext>(options);
         
            var target = new UserController(context, _logger);
            
            var result = target.Index();
            var jsonResult = result as JsonResult;

            Assert.IsNotNull(result);

            if (jsonResult != null)
            {
                var assertResult = jsonResult.Value as IList<UserAmount>;
                if (assertResult != null)
                {
                    Assert.AreEqual(JeremyUser.Username, assertResult[0].Username);
                }
            }      
            
        }

        [TestMethod]
        public void SaveUserAmountNull()
        {
            var options = new DbContextOptions<AkqaDataStoreContext>();
            var context = Substitute.For<FakeAkqaDbContext>(options);
            var target = new UserController(context, _logger);

            var result = target.Save(null);
            
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void SaveUserAmountOk()
        {
            var options = new DbContextOptions<AkqaDataStoreContext>();
            var context = Substitute.For<FakeAkqaDbContext>(options);
            var target = new UserController(context, _logger);

            // Fake save Ok //
            context.SaveChanges().Returns(1);

            var userModel = new UserModel { Username = "Edward Lee", Amount = 2000_00, Id = 111 };
            var fakeUserAmount = new UserAmount() { Username = "Edward Lee", Amount = 2000_00, Id = 111 };

            context.Find<UserAmount>().ReturnsForAnyArgs(fakeUserAmount);

            var result = target.Save(userModel);

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        [TestMethod]
        public void SaveUserAmountFalseReturnNoReturnStatus()
        {
            var options = new DbContextOptions<AkqaDataStoreContext>();
            var context = Substitute.For<FakeAkqaDbContext>(options);
            var target = new UserController(context, _logger);

            // Fake save not successful  //
            context.SaveChanges().Returns(0);

            var userModel = new UserModel { Username = "Edward Lee", Amount = 2000_00, Id = 111 };
            var fakeUserAmount = new UserAmount() { Username = "Edward Lee", Amount = 2000_00, Id = 111 };

            context.Find<UserAmount>().ReturnsForAnyArgs(fakeUserAmount);

            var result = target.Save(userModel);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        
    }
}
