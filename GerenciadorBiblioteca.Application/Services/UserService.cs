using GerenciadorBiblioteca.Core.DTO.Users;
using GerenciadorBiblioteca.Core.Entities;
using GerenciadorBiblioteca.Core.Interfaces.Repositories;
using GerenciadorBiblioteca.Core.Interfaces.Services;

namespace GerenciadorBiblioteca.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateUserDto model)
        {
            var user = model.ToEntity();

            await _repository.Create(user);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _repository.GetById(id);

            if (user is null)
                return null;
            
            var dto = UserDto.FromEntity(user);

            return dto;
        }
    }
}
