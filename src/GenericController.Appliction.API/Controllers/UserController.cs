using GenericController.Appliction.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericController.Appliction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : GenericBaseController<User>
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
