using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Core.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Task Create(Loan loan);
        Task<List<Loan>> GetAll();
        Task<Loan> GetById(int id);
        Task Update(Loan loan);
    }
}
