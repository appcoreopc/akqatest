using AkqaDataServices;
using AkqaDataServices.DataModel;
using AkqaWebApi.ServiceLayer;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AkqaWebApiTest
{
    public class TestBase
    {
        protected IAkqaDataContext _mockContext;
        protected UserAmountDataService _userAmountDataService;

        protected UserAmount JeremyUser = new UserAmount { Id = 1, Username = "JEREMY", Amount = 8888_00 };
        protected UserAmount RobUser = new UserAmount { Id = 1, Username = "JEREMY", Amount = 2300_00 };
        protected UserAmount NickUser = new UserAmount { Id = 1, Username = "JEREMY", Amount = 7700_00 };

        protected void InitTestCase()
        {
            var userAmountFakeData = new List<UserAmount>
            {
                JeremyUser,
                RobUser,  
                NickUser

            }.AsQueryable();

            var userAmountMock = Substitute.For<DbSet<UserAmount>, IQueryable<UserAmount>>();
            ((IQueryable<UserAmount>)userAmountMock).Provider.Returns(userAmountFakeData.Provider);
            ((IQueryable<UserAmount>)userAmountMock).Expression.Returns(userAmountFakeData.Expression);
            ((IQueryable<UserAmount>)userAmountMock).ElementType.Returns(userAmountFakeData.ElementType);
            ((IQueryable<UserAmount>)userAmountMock).GetEnumerator().Returns(userAmountFakeData.GetEnumerator());
            
            _mockContext = Substitute.For<IAkqaDataContext>();

            _mockContext.UserAmount.Returns(userAmountMock);

            _userAmountDataService = new UserAmountDataService(_mockContext);

                  

        }
    }

}
