using Entities.DataTransferObjects;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services;
using Services.Contracts;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _manager.BookService.GetAllBooksAsync(false); // Asenkron çağrı
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.BookService.GetOneBookAsync(id, false); // Asenkron çağrı
            return Ok(book);
        }

        
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book = await _manager.BookService.CreateOneBookAsync(bookDto); // Asenkron çağrı
            return StatusCode(201, book);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto is null)
                return BadRequest();

            await _manager.BookService.UpdateOneBookAsync(id, bookDto, true); // Asenkron çağrı
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.BookService.GetOneBookAsync(id, false); // Asenkron çağrı
            if (book == null)
                return NotFound();

            await _manager.BookService.DeleteOneBookAsync(id, false); // Asenkron çağrı
            return NoContent();
        }
    }
}
