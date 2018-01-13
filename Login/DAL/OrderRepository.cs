using WebDBApp.Database;
using WebDBApp.Models;

namespace WebDBApp.DAL
{
    public class OrderRepository : Repository<Order, int>
    {

        public OrderRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}