using System.Collections.Generic;

namespace AkqaWebApi.ServiceLayer
{
    internal interface IAppObjectService<T, T2>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(int skipAmount, int takeAmount);

        bool Save(T2 requestUser);
    }
}