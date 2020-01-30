using System.Collections.Generic;
using System.Linq;
using WebDBApp.Database;
using WebDBApp.Models;
using System.Data.Entity;

namespace WebDBApp.DAL
{
    public class RoomRepository : Repository<Room, int>
    {

        public RoomRepository(AppDbContext context)
            : base(context)
        {
        }


        public override List<Room> All()
        {
            return Set.Include(S => S.Accessories ).Include(g => g.Building).ToList();
        }
    }
}