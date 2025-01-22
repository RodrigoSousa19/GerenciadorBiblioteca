using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task Update(User user);
    }
}
