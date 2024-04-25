using ApiSourceCode.Models.Domain;
using ApiSourceCode.Servieces;
using Microsoft.AspNetCore.Mvc;

namespace ApiSourceCode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        protected readonly InterAuthor _interAuthor;
        public AuthorController(InterAuthor interAuthor) 
        {
        _interAuthor = interAuthor;
        }
        [HttpGet]
        public IActionResult Getall()
        {
            try
            {
                
                return Ok(_interAuthor.GetAllAuthor());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            try
            {
                
                return Ok(_interAuthor.GetAuthor(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Add(AddAuthorDTO author)
        {
            try
            {
                _interAuthor.AddAuthor(author);
                return Ok();
            }
            catch
            {
                    return BadRequest();
            }
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                _interAuthor.DeleteAuthor(id);
                return Ok();
            }
            catch
            {
               return NotFound();
            }
        }
        [HttpPut]
        public IActionResult Update(AuthorDTO author) 
        {
            try
            {
                
                return Ok(_interAuthor.UpdateAuthor(author));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
