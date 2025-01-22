using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Application.DTO.Users
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User ToEntity() => new(Name, Email);
    }
}
