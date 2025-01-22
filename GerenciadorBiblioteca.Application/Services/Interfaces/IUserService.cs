using GerenciadorBiblioteca.Application.DTO.Users;

namespace GerenciadorBiblioteca.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(CreateUserDto model);
        Task<UserDto> GetById(int id);
    }
}
