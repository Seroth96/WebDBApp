using System.Collections.Generic;
using WebDBApp.Database;
using WebDBApp.Models;
using System.Data.Entity;
using System.Linq;

namespace WebDBApp.DAL
{
    public class BuildingRepository : Repository<Building, int>
    {

        public BuildingRepository(AppDbContext context)
            : base(context)
        {
        }

        public override List<Building> All()
        {
            return Set.Include(s => s.Rooms).ToList();
        }
    }
}