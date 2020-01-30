using WebDBApp.Models;

using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections;

namespace WebDBApp.Database
{
    public class AppDbContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingDetails> BuildingDetails { get; set; }

        public AppDbContext()
            : base("DBContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            System.Data.Entity.Database.SetInitializer<AppDbContext>(null);
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<User>()
                .HasMany(v => v.CalendarEvents)
                .WithMany(p => p.Users).Map(m =>
                 {
                m.MapLeftKey("Login");
                m.MapRightKey("CalendarEventID");
                m.ToTable("UsersEvents");
            });

        }
    }
}