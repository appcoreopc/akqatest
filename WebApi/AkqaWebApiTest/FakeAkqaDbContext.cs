using System.Collections.Generic;
using AkqaDataServices.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NSubstitute;

namespace AkqaWebApiTest
{
    public class FakeAkqaDbContext : AkqaDataStoreContext, IAkqaDataContext
    {
        protected UserAmount JeremyUser = new UserAmount { Id = 1, Username = "JEREMY", Amount = 8888_00 };
        protected UserAmount RobUser = new UserAmount { Id = 1, Username = "ROB", Amount = 2300_00 };
        protected UserAmount NickUser = new UserAmount { Id = 1, Username = "NICK", Amount = 7700_00 };
        
        DbSet<UserAmount> _userAmountQueryable; 
               
        public FakeAkqaDbContext(DbContextOptions<AkqaDataStoreContext> options) : base(options)
        {
            var userAmountFakeData = new List<UserAmount>
            {
                JeremyUser,
                RobUser,
                NickUser

            }.AsQueryable();

            _userAmountQueryable = Substitute.For<DbSet<UserAmount>, IQueryable<UserAmount>>();
            ((IQueryable<UserAmount>)_userAmountQueryable).Provider.Returns(userAmountFakeData.Provider);
            ((IQueryable<UserAmount>)_userAmountQueryable).Expression.Returns(userAmountFakeData.Expression);
            ((IQueryable<UserAmount>)_userAmountQueryable).ElementType.Returns(userAmountFakeData.ElementType);
            ((IQueryable<UserAmount>)_userAmountQueryable).GetEnumerator().Returns(userAmountFakeData.GetEnumerator());
        }

        public DbSet<UserAmount> UserAmount
        {
            get
            {
                return _userAmountQueryable;
            }
        }
    }
}
