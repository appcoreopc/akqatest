using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using AkqaDataServices.DataModel;
using Microsoft.EntityFrameworkCore;
using AkqaWebApi.ServiceLayer;
using System.Linq;

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
    }
}
