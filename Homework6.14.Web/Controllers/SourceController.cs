using Homework6._14.Data;
using Homework6._14.Web.View_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework6._14.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private readonly string _connectionString;
        public SourceController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpPost]
        [Route("addsource")]
        public void AddSource(Source source)
        {
            var repo = new SourceRepository(_connectionString);
            repo.AddSource(source);
        }

        [HttpPost]
        [Route("updatesource")]
        public void UpdateSource(Source source)
        {
            var repo = new SourceRepository(_connectionString);
            repo.UpdateSource(source);
        }

        [HttpPost]
        [Route("deletesource")]
        public void DeleteSource(Source source)
        {
            var repo = new SourceRepository(_connectionString);
            repo.DeleteSource(source.Id);
        }

        [HttpGet]
        [Route("getallsources")]
        public List<Source> GetAllSources()
        {
            var repo = new SourceRepository(_connectionString);
            return repo.GetAllSources();
        }
    }
}
