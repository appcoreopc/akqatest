using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AkqaWebApi.ServiceLayer;
using System.Linq;
using NSubstitute;
using AkqaDataServices.DataModel;
using AkqaWebApi.Models;

namespace AkqaWebApiTest.ServiceLayer
{
    [TestClass]
    public class UserAmountDataServiceTest : TestBase
    {
        [TestInitializeAttribute]
        public void TestCaseInit()
        {
            // Arrange //
            InitTestCase();
        }

        [TestMethod]
        public void GetUserAmountAll()
        {
            // Arrange 
            _userAmountDataService = new UserAmountDataService(_mockContext);

            // Act 
            var result = _userAmountDataService.GetAll().ToList();

            // Assert 
            Assert.IsNotNull(result);

            Assert.IsTrue(result.Count == 3);

            Assert.IsTrue(string.Equals(result[0].Username, JeremyUser.Username, StringComparison.InvariantCultureIgnoreCase));

        }

        [TestMethod]
        public void DoesNotSaveNull()
        {
            // Arrange 
            _userAmountDataService = new UserAmountDataService(_mockContext);

            // Act 
            _userAmountDataService.Save(null);

            // Assert 
            _mockContext.DidNotReceive().SaveChanges();

        }

        [TestMethod]
        public void SaveUserAmountSuccessful()
        {
            _mockContext.SaveChanges().Returns(1);

            // Arrange 
            _userAmountDataService = new UserAmountDataService(_mockContext);

            // Act 
            var saveResults = _userAmountDataService.Save(new UserModel()
            {
                Username = "Test",
                Amount = 2399_00
            });

            // Assert 
            _mockContext.Received().SaveChanges();

            Assert.IsTrue(saveResults);

        }
    }
}
