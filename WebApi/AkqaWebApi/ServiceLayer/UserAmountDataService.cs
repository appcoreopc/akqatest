using AkqaDataServices.DataModel;
using AkqaWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AkqaWebApiTest")]
namespace AkqaWebApi.ServiceLayer
{
    public class UserAmountDataService : AppDataObject, IAppObjectService<UserAmount, UserModel>
    {
        public UserAmountDataService(IAkqaDataContext context) : base(context)
        {

        }

        public IEnumerable<UserAmount> GetAll()
        {
            return base._context.UserAmount.ToList();
        }

        public IEnumerable<UserAmount> GetAll(int skipAmount, int takeAmount)
        {
            return _context.UserAmount.Skip(skipAmount).Take(takeAmount);
        }

        public bool Delete(int id)
        {
            return Remove<UserAmount>(id);
        }

        public bool Save(UserModel requestUser)
        {
            if (requestUser != null)
            {
                if (!requestUser.Id.HasValue)
                {
                    var user = new UserAmount()
                    {
                        Username = requestUser.Username,
                        Amount = requestUser.Amount
                    };

                    return base.Save<UserAmount>(user, null);
                }
                else
                {
                    var employee = FindById<UserAmount>(requestUser.Id.Value);

                    if (employee != null)
                    {
                        employee.Amount = requestUser.Amount;
                        employee.Username = requestUser.Username;
                        return base.Save<UserAmount>(employee, employee.Id);
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
