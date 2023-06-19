using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6._14.Data
{
    public class IncomeRepository
    {
        private readonly string _connectionString;
        public IncomeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Income income)
        {
            var context = new TrackerDbContext(_connectionString);
            context.Incomes.Add(income);
            context.SaveChanges();
        }

        public List<Source> GetAllIncomesGrouped()
        {
            var context = new TrackerDbContext(_connectionString);
            return context.Sources.Include(i => i.Incomes).ToList();
        }

        public List<IncomeWithSourceName> GetIncomesGrouped()
        {
            var context = new TrackerDbContext(_connectionString);
            var list = context.Incomes.Include(s => s.Source).ToList();
            var incomes = new List<IncomeWithSourceName>();
            foreach (var i in list)
            {
                incomes.Add(new IncomeWithSourceName()
                {
                    Id = i.Id,
                    SourceId = i.Id,
                    Amount = i.Amount,
                    Date = i.Date,
                    SourceName = i.Source.IncomeSource
                });
            }
            return incomes;
        }

        public decimal IncomeTotal()
        {
            var context = new TrackerDbContext(_connectionString);
            return context.Incomes.Select(i => i.Amount).Sum();

        }

        public decimal MaaserObligated()
        {
            var context = new TrackerDbContext(_connectionString);
            return context.Incomes.Select(i => i.Amount).Sum() / 100 * 10;
        }

        public decimal RemaningMaaser()
        {
            var maaserRepo = new MaaserRepository(_connectionString);
            return MaaserObligated() - maaserRepo.MaaserTotal();

        }
    }
}
