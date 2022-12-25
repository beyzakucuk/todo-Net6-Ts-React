using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using toDoApi.Models;

namespace toDoApi.DataAccess
{
    public class PostgreContext: DbContext
    {

        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
            
        }
        public DbSet<User> users { get; set; }

        public DbSet<Todo> todos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
