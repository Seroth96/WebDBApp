using Login.DAL;
using Login.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }
        //UserRepository UserRepository { get; set; }
        void SaveChanges();
    }
}
