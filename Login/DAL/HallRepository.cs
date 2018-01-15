using System.Collections.Generic;
using System.Linq;
using WebDBApp.Database;
using WebDBApp.Models;
using System.Data.Entity;

namespace WebDBApp.DAL
{
    public class HallRepository : Repository<Hall, int>
    {

        public HallRepository(AppDbContext context)
            : base(context)
        {
        }


        public override List<Hall> All()
        {
            return Set.Include(S => S.Accessories ).Include(g => g.Gym).ToList();
        }
    }
}