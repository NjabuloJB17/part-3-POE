using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Part_2.database;
using Part_2.models;

namespace Part_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetPerformance()
        {
            get_performance performance = new get_performance();

            var result = performance.get_all_performance();

            return Content(string.Join("\n", result));
        }

        // GET
        [HttpGet("participant/{id}")]
        public IActionResult GetPerformanceByParticipant(int id)
        {
            get_performance performance = new get_performance();

            var result = performance.get_performance_by_participant(id);

            if (result.Count == 0)
            {
                return NotFound("No performance records found for this participant");
            }

            return Content(string.Join("\n", result));
        }

        // POST
        [HttpPost]
        public IActionResult AddPerformance(perform request)
        {
            get_performance performance = new get_performance();

            string result = performance.add_performance(
                request.performance_history,
                request.participant_id
            );

            if (result == string.Empty)
            {
                return BadRequest("Could not add performance record");
            }

            return Content(result);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult UpdatePerformance(int id, perform request)
        {
            get_performance performance = new get_performance();

            string result = performance.update_performance(
                id,
                request.performance_history
            );

            if (result == string.Empty)
            {
                return NotFound("Performance record not found");
            }

            return Content(result);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeletePerformance(int id)
        {
            get_performance performance = new get_performance();

            string result = performance.delete_performance(id);

            if (result == string.Empty)
            {
                return NotFound("Performance record not found");
            }

            return Content(result);
        }

    }
}
