using GerenciadorBiblioteca.Core.Entities;
using GerenciadorBiblioteca.Core.Interfaces.Repositories;
using GerenciadorBiblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GerenciadorBibliotecaDbContext _context;
        public UserRepository(GerenciadorBibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetById(int id) => await _context.Users.Include(l => l.BookLoans).SingleOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        public async Task<List<User>> GetAll() => await _context.Users.ToListAsync();

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
