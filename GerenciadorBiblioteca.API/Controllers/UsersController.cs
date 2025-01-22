using GerenciadorBiblioteca.Application.DTO.Users;
using GerenciadorBiblioteca.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetById(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserDto model)
        {
            var user = model.ToEntity();

            await _service.Create(model);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, model);
        }
    }
}
