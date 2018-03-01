namespace AkqaWebApi.ServiceLayer
{
    public interface IAppDataObject
    {
        bool Remove<T>(params int[] ids) where T : class;


        bool Save<T>(T target, int? uniqueId) where T : class;

        bool Add<T>(T target) where T : class;

        T FindById<T>(int id) where T : class;


    }
}