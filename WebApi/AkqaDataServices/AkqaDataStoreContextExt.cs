using Microsoft.EntityFrameworkCore;

namespace AkqaDataServices.DataModel
{
    public partial class AkqaDataStoreContext : DbContext, IAkqaDataContext
    {
        public AkqaDataStoreContext(DbContextOptions<AkqaDataStoreContext> options) : base(options)
        {

        }
    }
}
