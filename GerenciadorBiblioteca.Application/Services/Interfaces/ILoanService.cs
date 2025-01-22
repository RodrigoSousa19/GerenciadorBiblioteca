using GerenciadorBiblioteca.Application.DTO.Loans;

namespace GerenciadorBiblioteca.Core.Interfaces.Services
{
    public interface ILoanService
    {
        Task Create(CreateLoanDto model);
        Task Delete(int id);
        Task<List<LoanDto>> GetAll();
        Task<LoanDto> GetById(int id);
        Task<string> ReturnBook(int id);
        Task Update(int id, UpdateLoanDto model);
    }
}
