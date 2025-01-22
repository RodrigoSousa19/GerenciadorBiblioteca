using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Core.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task Create(Book book);
        Task<List<Book>> GetAll();
        Task<Book> GetById(int id);
        Task Update(Book book);
    }
}
