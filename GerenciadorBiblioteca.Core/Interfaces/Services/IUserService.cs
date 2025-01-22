using GerenciadorBiblioteca.Core.DTO.Users;

namespace GerenciadorBiblioteca.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task Create(CreateUserDto model);
        Task<UserDto> GetById(int id);
    }
}
