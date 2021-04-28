using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusPoolController : ControllerBase
    {
        // GET: api/<BonusPoolController>
        [HttpGet]
        public IActionResult GetAll()
        {
             IEnumerable<string> result = new string[] { "value1", "value2" };
            return Ok(result);
        }

        // GET api/<BonusPoolController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BonusPoolController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
