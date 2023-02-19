using DataAccess.Concrete.EntityFramework.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
    public class ECommerceProjectWithWebAPIContext :DbContext
    {
    public ECommerceProjectWithWebAPIContext(DbContextOptions<ECommerceProjectWithWebAPIContext> options) : base(options)
    {

    }
    public ECommerceProjectWithWebAPIContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       base.OnConfiguring(optionsBuilder);
       optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ECommerceProjectWithWebAPIDb;Trusted_Connection=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }

        public virtual DbSet<User> Users { get; set; }
    }
}

