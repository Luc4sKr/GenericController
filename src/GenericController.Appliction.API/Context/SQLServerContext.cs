using GenericController.Appliction.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GenericController.Appliction.API.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> option) : base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.UpdateFields();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.UpdateFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        #region DbSets
        public DbSet<User> User { get; set; }
        #endregion

        #region Methods
        private void UpdateFields()
        {
            IEnumerable<EntityEntry<BaseModel>> modifyEntities = ChangeTracker.Entries<BaseModel>();
            DateTime currentTime = DateTime.Now;

            foreach (var entity in modifyEntities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedOn = currentTime;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedOn = currentTime;
                }
            }
        }
        #endregion
    }
}
