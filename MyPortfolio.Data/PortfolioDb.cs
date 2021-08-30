namespace MyPortfolio.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Data.Models.Base;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class PortfolioDb : IdentityDbContext<User>
    {
        public PortfolioDb(DbContextOptions<PortfolioDb> options) 
            :base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Education> Educations { get; set; } 

        public DbSet<Experience> Experiences { get; set; } 

        public DbSet<Hobie> Hobies { get; set; } 

        public DbSet<Project> Projects { get; set; } 

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Message> Messages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationData.ConnectionString); 
            }

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInformation();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInformation();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder) 
            => base.OnModelCreating(builder);

        private void ApplyAuditInformation()
         => this.ChangeTracker
              .Entries()
              .Select(entry => new
              {
                  entry.Entity,
                  entry.State
              })
              .ToList()
              .ForEach(entry =>
              {
                  if (entry.Entity is IDeletableEntity deletableEntity)
                  {
                      if (entry.State == EntityState.Deleted)
                      {
                          deletableEntity.DeletedOn = DateTime.UtcNow;
                          deletableEntity.IsDeleted = true;
                      }
                  }

                  if (entry.Entity is IEntity entity)
                  {
                      if (entry.State is EntityState.Added)
                      {
                          entity.CreatedOn = DateTime.UtcNow;
                      }
                      else if (entry.State is EntityState.Modified)
                      {
                          entity.ModifiedOn = DateTime.UtcNow;
                      }
                  }
              });
    }
}
