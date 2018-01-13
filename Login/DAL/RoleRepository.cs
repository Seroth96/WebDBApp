using WebDBApp.Database;
using WebDBApp.Enum;
using WebDBApp.Extensions;
using WebDBApp.Helpers;
using WebDBApp.Interfaces;
using WebDBApp.Models;
using WebDBApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using NLog;

namespace WebDBApp.DAL
{
    public class RoleRepository : Repository<Role, int>
    {
        
        public RoleRepository(AppDbContext context)
            : base(context)
        {
        }

        public  Role Find(string name)
        {
            return Set.First(role => role.Name.Equals(name));
        }

    }
}