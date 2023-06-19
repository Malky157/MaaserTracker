using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6._14.Data
{
    public class MaaserRepository
    {
        private readonly string _connectionString;
        public MaaserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Maaser maser)
        {
            var context = new TrackerDbContext(_connectionString);
            context.Maasers.Add(maser);
            context.SaveChanges();
        }

        public List<Maaser> GetAllMaaser()
        {
            var context = new TrackerDbContext(_connectionString);
            return context.Maasers.OrderBy(m => m.Date).ToList();
        }

        public decimal MaaserTotal()
        {
            var context = new TrackerDbContext(_connectionString);
            return context.Maasers.Select(m => m.Amount).Sum();
        }

      
    }
}
