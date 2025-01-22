using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Application.DTOs.Users
{
    public class UserDto
    {
        public UserDto(string name, string email, List<Loan> bookLoans)
        {
            Name = name;
            Email = email;
            BookLoans = bookLoans;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public List<Loan> BookLoans { get; private set; }

        public static UserDto FromEntity(User user) => new UserDto(user.Name, user.Email, user.BookLoans);
    }
}
