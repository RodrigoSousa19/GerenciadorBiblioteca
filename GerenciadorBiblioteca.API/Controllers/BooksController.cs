using GerenciadorBiblioteca.Core.DTO.Books;
using GerenciadorBiblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _service.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _service.GetById(id);

            if (book is null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookDto model)
        {
            var book = model.ToEntity();

            await _service.Create(model);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookDto model)
        {
            await _service.Update(id, model);

            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}/set-available")]
        public async Task<IActionResult> SetAvailable(int id)
        {
            await _service.SetAvailableForLoan(id);

            return NoContent();
        }

        [HttpPut("{id}/set-unavailable")]
        public async Task<IActionResult> SetUnavailable(int id)
        {
            await _service.SetUnavailableForLoan(id);

            return NoContent();
        }
    }
}
