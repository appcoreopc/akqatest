using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AkqaWebApiTest")]

namespace AkqaDataServices.DataModel
{
    public partial class AkqaDataStoreContext : DbContext, IAkqaDataContext
    {
        public virtual DbSet<UserAmount> UserAmount { get; set; }
             

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAmount>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}