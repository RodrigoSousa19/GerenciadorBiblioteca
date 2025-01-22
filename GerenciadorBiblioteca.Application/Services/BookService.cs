using GerenciadorBiblioteca.Core.DTO.Books;
using GerenciadorBiblioteca.Core.Interfaces.Repositories;
using GerenciadorBiblioteca.Core.Interfaces.Services;

namespace GerenciadorBiblioteca.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateBookDto model)
        {
            var book = model.ToEntity();

            await _repository.Create(book);
        }

        public async Task<BookDto> GetById(int id)
        {
            var book = await _repository.GetById(id);

            if (book is null)
                return null;

            var dto = BookDto.FromEntity(book);

            return dto;
        }

        public async Task<List<BookDto>> GetAll()
        {
            var books = await _repository.GetAll();

            var dto = books.Select(BookDto.FromEntity).ToList();

            return dto;
        }

        public async Task Update(int id, UpdateBookDto model)
        {
            var book = await _repository.GetById(id);

            book.Update(model.Title, model.Author, model.Isbn, model.PublicationYear);

            await _repository.Update(book);
        }

        public async Task Delete(int id)
        {
            var book = await _repository.GetById(id);

            book.SetAsDeleted();

            await _repository.Update(book);
        }

        public async Task SetAvailableForLoan(int id)
        {
            var book = await _repository.GetById(id);

            book.SetAvailableForLoan();

            await _repository.Update(book);
        }

        public async Task SetUnavailableForLoan(int id)
        {
            var book = await _repository.GetById(id);

            book.SetUnavailableForLoan();

            await _repository.Update(book);
        }
    }
}
