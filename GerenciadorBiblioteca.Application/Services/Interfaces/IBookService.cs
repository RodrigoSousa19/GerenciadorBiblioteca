using GerenciadorBiblioteca.Application.DTO.Books;

namespace GerenciadorBiblioteca.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task Create(CreateBookDto model);
        Task Delete(int id);
        Task<List<BookDto>> GetAll();
        Task<BookDto> GetById(int id);
        Task SetAvailableForLoan(int id);
        Task SetUnavailableForLoan(int id);
        Task Update(int id, UpdateBookDto model);
    }
}
