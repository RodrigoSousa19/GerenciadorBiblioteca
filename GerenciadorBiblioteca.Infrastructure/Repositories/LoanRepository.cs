using GerenciadorBiblioteca.Core.Entities;
using GerenciadorBiblioteca.Core.Interfaces.Repositories;
using GerenciadorBiblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly GerenciadorBibliotecaDbContext _context;

        public LoanRepository(GerenciadorBibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task Create(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<Loan> GetById(int id) => await _context.Loans.Include(u => u.User).Include(b => b.Book).SingleOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        public async Task<List<Loan>> GetAll() => await _context.Loans.Include(u => u.User).Include(b => b.Book).ToListAsync();

        public async Task Update(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}
