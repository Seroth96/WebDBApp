using WebDBApp.Database;
using WebDBApp.Models;

namespace WebDBApp.DAL
{
    public class GymRepository : Repository<Order, int>
    {

        public GymRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}