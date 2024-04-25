using ApiSourceCode.Data;
using ApiSourceCode.Models.Domain;
using ApiSourceCode.Servieces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext appDbContext; 
            private readonly InterBook _interBook;
            public BooksController(InterBook interBook,AppDbContext appDbContext)
            {
                _interBook = interBook;
            appDbContext = appDbContext;
            }
            [HttpGet]
            public IActionResult Getall()
            {
            var allbook = _interBook.GetAllBook();
            return Ok(allbook);
            }
            [HttpGet("id")]
            public IActionResult Get(int id)
            {
                try
                {
                    return Ok(_interBook.GetBook(id));
                }
                catch
                {
                    return BadRequest();
                }
            }
            [HttpPost]
            public IActionResult Add(BookDTO Book)
            {
                try
                {
                    _interBook.AddBook(Book);
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
                    _interBook.DeleteBook(id);
                    return Ok();
                }
                catch
                {
                    return NotFound();
                }
            }
            [HttpPut]
            public IActionResult Update(BookDTO Book)
            {
                try
                {
                    return Ok(_interBook.UpdateBook(Book));
                }
                catch
                {
                    return NotFound();
                }
            }
        
    }
}
