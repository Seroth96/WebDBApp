using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDBApp.Interfaces
{
    public interface IHashHelper
    {
        //string Compute(string input);
        string Compute(string pwd, string salt);
        string GetSalt();
    }
}
