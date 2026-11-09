using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Part_2.database;
using Part_2.models;

namespace Part_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            get_enrollment enrollment = new get_enrollment();

            var result = enrollment.get_all_enrollments();

            return Ok(result);
        }
    
// POST
[HttpPost]
public IActionResult AddEnrollment(enrollment_request request)
        {
            get_enrollment enrollment = new get_enrollment();

            string result = enrollment.add_enrollment(
                request.participant_id,
                request.events_id,
                request.categories_id
            );

            if (result == string.Empty)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        
            // GET
            [HttpGet("participant/{id}")]
       public IActionResult GetEnrollmentsByParticipant(int id)
        {
            get_enrollment enrollment = new get_enrollment();

            var result = enrollment.get_enrollments_by_participant(id);

            return Ok(result);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            get_enrollment enrollment = new get_enrollment();

            string result = enrollment.delete_enrollment(id);

            if (result == string.Empty)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }

}