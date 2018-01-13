namespace WebDBApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    internal sealed class Configuration : DbMigrationsConfiguration<WebDBApp.Database.AppDbContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
           // ContextKey = "Login.Database.LoginDbContext";
        }

        protected override void Seed(WebDBApp.Database.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            if (!context.Roles.Any(role => role.Name.Equals("Klient")))
            {
                byte[] bytes = Encoding.Default.GetBytes("Klient");
                var myString = Encoding.ASCII.GetString(bytes);
                context.Roles.Add(new Models.Role { Name = myString });
            }
            if (!context.Roles.Any(role => role.Name.Equals("Administrator")))
            {
                context.Roles.Add(new Models.Role { Name = "Administrator" });
            }
            if (!context.Roles.Any(role => role.Name.Equals("Trener")))
            {
                context.Roles.Add(new Models.Role { Name = "Trener" });
            }
        }
    }
}
