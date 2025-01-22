using GerenciadorBiblioteca.Core.DTO.Loans;
using GerenciadorBiblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoansController(ILoanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = await _service.GetAll();

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = await _service.GetById(id);

            if (loan is null)
                return NotFound();
            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLoanDto model)
        {
            await _service.Create(model);

            var loan = model.ToEntity();

            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateLoanDto model)
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

        [HttpPut("{id}/return-book")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var response = await _service.ReturnBook(id);

            return Ok(response);
        }
    }
}
