using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2.database;
using Part_2.models;

namespace Part_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetCategories()
        {
            get_categories categories = new get_categories();

            var result = categories.get_all_categories();

            return Ok(result);
        }
    
    
        // GET
       [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            get_categories categories = new get_categories();

            string result = categories.get_category_by_id(id);

            if (result == string.Empty)
            {
                return NotFound();
            }

            return Ok(result);
        }

// PUT
[HttpPut("{id}")]
public IActionResult UpdateCategory(int id, category request)
        {
            get_categories categories = new get_categories();

            string result = categories.update_category(
                id,
                request.categories_name
            );

            if (result == string.Empty)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
// DELETE
[HttpDelete("{id}")]
public IActionResult DeleteCategory(int id)
        {
            get_categories categories = new get_categories();

            string result = categories.delete_category(id);

            if (result == string.Empty)
            {
                return NotFound();
            }

            return Ok(result);
        }
       
            // POST
        [HttpPost]
        public IActionResult AddCategory(category request)
        {
            get_categories categories = new get_categories();

            string result = categories.add_category(
                request.categories_name,
                request.events_id
            );

            if (result == string.Empty)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}