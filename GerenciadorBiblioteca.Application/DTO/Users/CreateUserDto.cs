using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Application.DTOs.Users
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User ToEntity() => new(Name, Email);
    }
}
