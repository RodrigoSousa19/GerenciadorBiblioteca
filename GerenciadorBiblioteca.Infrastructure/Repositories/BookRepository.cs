using GerenciadorBiblioteca.Core.Entities;
using GerenciadorBiblioteca.Core.Interfaces.Repositories;
using GerenciadorBiblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly GerenciadorBibliotecaDbContext _context;

        public BookRepository(GerenciadorBibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetById(int id) => await _context.Books.SingleOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        public async Task<List<Book>> GetAll() => await _context.Books.Where(b => !b.IsDeleted).ToListAsync();

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
