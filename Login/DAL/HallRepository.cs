using WebDBApp.Database;
using WebDBApp.Models;

namespace WebDBApp.DAL
{
    public class HallRepository : Repository<Hall, int>
    {

        public HallRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}