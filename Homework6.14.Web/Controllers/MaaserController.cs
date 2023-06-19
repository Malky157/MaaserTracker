using Homework6._14.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework6._14.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaaserController : ControllerBase
    {
        private readonly string _connectionString;
        public MaaserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpPost]
        [Route("addmaaser")]
        public void AddMaaser(Maaser maaser)
        {
            var repo = new MaaserRepository(_connectionString);
            repo.Add(maaser);
        }

        [HttpGet]
        [Route("getallmaaser")]
        public List<Maaser> GetAllMaaser()
        {
            var repo = new MaaserRepository(_connectionString);
            return repo.GetAllMaaser();
        }

        [HttpGet]
        [Route("getmaasertotal")]
        public decimal GetMaaserCount()
        {
            var repo = new MaaserRepository(_connectionString);
            return repo.MaaserTotal();
        }

        
    }
}
