using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2.database;
using Part_2.models;
using System.Data.SqlClient;

namespace Part_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        // GET: api/Results
        [HttpGet]
        public IActionResult GetResults()
        {
            get_results results = new get_results();

            string result = results.get_all_results();

            if (result == "")
            {
                return NotFound("No results found");
            }

            return Content(result);
        }

        // POST
        [HttpPost]
        public IActionResult AddResults(results request)
        {
            get_results results = new get_results();

            string result = results.add_results(
                request.participant_id,
                request.events_id,
                request.result_time,
                request.result_position
            );

            if (result == "")
            {
                return BadRequest("Could not add result");
            }

            return Content(result);
        }



        // GET
        [HttpGet("{id}")]
        public IActionResult GetResultById(int id)
        {
            get_results results = new get_results();

            string result = results.get_result_by_id(id);

            if (result == "")
            {
                return NotFound("Result not found");
            }

            return Content(result);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult UpdateResults(int id, results request)
        {
            get_results results = new get_results();

            string result = results.update_results(
                id,
                request.participant_id,
                request.events_id,
                request.result_time,
                request.result_position
            );

            if (result == "")
            {
                return NotFound("Result not found");
            }

            return Content(result);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteResults(int id)
        {
            get_results results = new get_results();

            string result = results.delete_results(id);

            if (result == "")
            {
                return NotFound("Result not found");
            }

            return Content(result);
        }

    }
}
