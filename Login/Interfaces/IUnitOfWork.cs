using WebDBApp.DAL;
using WebDBApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDBApp.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext Context { get; set; }
        UserRepository UserRepository { get; set; }
        RoleRepository RoleRepository { get; set; }        
        CalendarEventsRepository CalendarEventsRepository { get; set; }
        AccessoryRepository AccessoryRepository { get; set; }
        EventTypeRepository EventTypeRepository { get; set; }
        RoomRepository RoomRepository { get; set; }
        OrderRepository OrderRepository { get; set; }
        BuildingRepository BuildingRepository { get; set; }
        //TestRepository TestRepository { get; set; }
        void SaveChanges();
    }
}
