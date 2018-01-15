using System.Collections.Generic;
using WebDBApp.Database;
using WebDBApp.Models;
using System.Data.Entity;
using System.Linq;

namespace WebDBApp.DAL
{
    public class GymRepository : Repository<Gym, int>
    {

        public GymRepository(AppDbContext context)
            : base(context)
        {
        }

        public override List<Gym> All()
        {
            return Set.Include(s => s.Halls).ToList();
        }
    }
}