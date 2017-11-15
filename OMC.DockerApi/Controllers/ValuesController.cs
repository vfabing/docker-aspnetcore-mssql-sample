using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace OMC.DockerApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IConfiguration _configuration;
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var result = new List<string>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("ValuesDatabase")))
            {
                // Connection Timeout at launch because SQL Server is not available from the start.
                // This is "normal" and should ideally be handle by implementing a retry system in the API
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM [ValuesDatabase].[dbo].[Values]", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(1));
                    }
                }
            }

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
