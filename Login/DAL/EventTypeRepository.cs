using WebDBApp.Database;
using WebDBApp.Models;

namespace WebDBApp.DAL
{
    public class EventTypeRepository : Repository<EventType, int>
    {

        public EventTypeRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}