using WebDBApp.Database;
using WebDBApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebDBApp.DAL
{
    internal class UnitOfWork : IDisposable, IUnitOfWork
    {
        public AppDbContext Context { get; set; }     
        public UserRepository UserRepository { get; set; }
        public RoleRepository RoleRepository { get; set; }
        public CalendarEventsRepository CalendarEventsRepository { get; set; }
        public AccessoryRepository AccessoryRepository { get; set; }
        public EventTypeRepository EventTypeRepository { get; set; }
        public RoomRepository RoomRepository { get; set; }
        public OrderRepository OrderRepository { get; set; }
        public BuildingRepository BuildingRepository { get; set; }
        //public TestRepository TestRepository { get; set; }

        public UnitOfWork()
        {
            Context = new AppDbContext();
            
            UserRepository = new UserRepository(Context, DependencyResolver.Current.GetService<IHashHelper>());
            RoleRepository = new RoleRepository(Context);
            CalendarEventsRepository = new CalendarEventsRepository(Context);
            AccessoryRepository = new AccessoryRepository(Context);
            EventTypeRepository = new EventTypeRepository(Context);
            RoomRepository = new RoomRepository(Context);
            OrderRepository = new OrderRepository(Context);
            BuildingRepository = new BuildingRepository(Context);
           // TestRepository = new TestRepository(Context);
        }

        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {

                    foreach (var ve in eve.ValidationErrors)
                    {
                        sb.Append(ve.ErrorMessage);
                        sb.Append(' ');
                        sb.Append(ve.PropertyName);
                        sb.Append(' ');
                    }
                }
                throw new Exception(sb.ToString());
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}