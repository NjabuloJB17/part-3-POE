using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2.database;
using Part_2.models;
namespace Part_2.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        //GET
        [HttpGet]
        public IActionResult GetEvents()
        {
            get_events events = new get_events();

            List<string> result = events.get_all_events();

            return Ok(result);
        }
       
            // POST
            [HttpPost]
        public IActionResult AddEvent(events request)
        {
            get_events events = new get_events();

            string result = events.add_event(
                request.events_name,
                request.events_date
            );

            if (result == string.Empty)
            {
                return BadRequest();
            }

            return Ok(result);
        }



        // GET: api/events/1
        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            get_events events = new get_events();

            string result = events.get_event_by_id(id);

            if (result == string.Empty)
            {
                return NotFound();
            }

            return Ok(result);
        }
    
   
                // PUT
        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, events request)
        {
            get_events events = new get_events();

            string result = events.update_event(
                id,
                request.events_name,
                request.events_date
            );

            if (result == string.Empty)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
    {
        get_events events = new get_events();

        string result = events.delete_event(id);

        if (result == string.Empty)
        {
            return NotFound();
        }

        return Ok(result);
    }

    }
}