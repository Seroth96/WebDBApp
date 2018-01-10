using Login.Models;

using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections;

namespace Login.Database
{
    public class DbContext : System.Data.Entity.DbContext
    {       
        public DbSet<User> Users { get; set; }
        public DbContext()
            : base("DBContext")
        {
            System.Data.Entity.Database.SetInitializer<DbContext>(null);
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}