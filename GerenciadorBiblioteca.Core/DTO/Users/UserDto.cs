using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Core.DTO.Users
{
    public class UserDto
    {
        public UserDto(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public static UserDto FromEntity(User user) => new UserDto(user.Name, user.Email);
    }
}
