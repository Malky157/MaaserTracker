using Homework6._14.Data;
using Homework6._14.Web.View_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework6._14.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly string _connectionString;
        public IncomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpPost]
        [Route("addincome")]
        public void AddIncome(Income income)
        {
            var repo = new IncomeRepository(_connectionString);
            repo.Add(income);
        }

        [HttpGet]
        [Route("getincomesgrouped")]
        public List<Source> GetAllIncomesGrouped()
        {
            var repo = new IncomeRepository(_connectionString);
            return repo.GetAllIncomesGrouped();
        }

        [HttpGet]
        [Route("getincomes")]
        public List<IncomeWithSourceName> GetIncomesGrouped()
        {
            var repo = new IncomeRepository(_connectionString);
            return repo.GetIncomesGrouped();
        }

        [HttpGet]
        [Route("getincometotal")]
        public decimal GetIncomeCount()
        {
            var repo = new IncomeRepository(_connectionString);
            return repo.IncomeTotal();
        }

        [HttpGet]
        [Route("getmaaserobligated")]
        public decimal GetMaaserObligated()
        {
            var repo = new IncomeRepository(_connectionString);
            return repo.MaaserObligated();
        }

        [HttpGet]
        [Route("getremainigmaaser")]
        public decimal GetRemaningMaaser()
        {
            var repo = new IncomeRepository(_connectionString);
            return repo.RemaningMaaser();
        }
    }


}
