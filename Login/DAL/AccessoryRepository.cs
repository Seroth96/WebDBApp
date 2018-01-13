using WebDBApp.Database;
using WebDBApp.Models;

namespace WebDBApp.DAL
{
    public class AccessoryRepository : Repository<Accessory, int>
    {

        public AccessoryRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}