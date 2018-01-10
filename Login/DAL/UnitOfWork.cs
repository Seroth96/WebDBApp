using Login.Database;
using Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Login.DAL
{
    internal class UnitOfWork : IDisposable, IUnitOfWork
    {
        public DbContext Context { get; set; }     
        //public UserRepository UserRepository { get; set; }

        public UnitOfWork()
        {
            Context = new DbContext();
            
            //UserRepository = new UserRepository(Context, DependencyResolver.Current.GetService<IHashHelper>());
            
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