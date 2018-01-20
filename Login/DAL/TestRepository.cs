using System.Collections.Generic;
using WebDBApp.Database;
using WebDBApp.Models;
using System.Data.Entity;
using System.Linq;

namespace WebDBApp.DAL
{
    public class TestRepository : Repository<Test, int>
    {

        public TestRepository(AppDbContext context)
            : base(context)
        {
        }

        public override List<Test> All()
        {
            return Set.Include(s => s.User).OrderBy(x => x.Name).ThenByDescending(y => y.DateOfTest).ToList();
        }
    }
}