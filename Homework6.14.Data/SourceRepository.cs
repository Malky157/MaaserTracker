using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6._14.Data
{
    public class SourceRepository
    {
        private readonly string _connectionString;
        public SourceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddSource(Source source)
        {
            var context = new TrackerDbContext(_connectionString);
            context.Sources.Add(source);
            context.SaveChanges();
        }

        public void UpdateSource(Source source)
        {
            var context = new TrackerDbContext(_connectionString);
            context.Sources.Update(source);
            context.SaveChanges();
        }

        public void DeleteSource(int sourceId)
        {
            var context = new TrackerDbContext(_connectionString);
            var source = context.Sources.FirstOrDefault(s => s.Id == sourceId);
            if (source != null)
            {
                //context.Sources.Remove(source); why doesn't this one work?
                context.Database.ExecuteSqlInterpolated($"Delete Sources WHERE Id = {sourceId}");
            }
        }

        public List<Source> GetAllSources()
        {
            var context = new TrackerDbContext(_connectionString);
            return context.Sources.OrderBy(i => i.IncomeSource).ToList();
        }
    }
}
