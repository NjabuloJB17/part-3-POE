using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2.database;
using Part_2.models;

namespace Part_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetProfiles()
        {
            get_profile profile = new get_profile();

            var result = profile.get_all_profiles();

            return Content(string.Join("\n", result));
        }

        // GET
        [HttpGet("{id}")]
        public IActionResult GetProfileById(int id)
        {
            get_profile profile = new get_profile();

            string result = profile.get_profile_by_id(id);

            if (result == string.Empty)
            {
                return NotFound("Participant profile not found");
            }

            return Content(result);
        }

       // PUT
        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, users request)
        {
            get_profile profile = new get_profile();

            string result = profile.update_profile(
                id,
                request.participant_name,
                request.participant_surname,
                request.participant_email,
                request.participant_number.ToString()
            );

            if (result == string.Empty)
            {
                return NotFound("Participant profile not found");
            }

            return Content(result);
        }

        // POST
        [HttpPost]
        public IActionResult AddProfile(users request)
        {
            get_profile profile = new get_profile();

            string result = profile.add_profile(
                request.participant_name,
                request.participant_surname,
                request.participant_email,
                request.participant_number.ToString()
            );

            if (result == string.Empty)
            {
                return BadRequest("Could not register participant");
            }

            return Content(result);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int id)
        {
            get_profile profile = new get_profile();

            string result = profile.delete_profile(id);

            if (result == string.Empty)
            {
                return NotFound("Participant profile not found");
            }

            return Content(result);
        }

     

    }
}
