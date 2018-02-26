using Microsoft.EntityFrameworkCore;

namespace AkqaDataServices.DataModel
{
    public partial class AkqaDataStoreContext : DbContext
    {
        public AkqaDataStoreContext(DbContextOptions<AkqaDataStoreContext> options) : base(options)
        {

        }
    }
}
