using WebDBApp.Database;
using WebDBApp.Models;

namespace WebDBApp.DAL
{
    public class GymRepository : Repository<Gym, int>
    {

        public GymRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}