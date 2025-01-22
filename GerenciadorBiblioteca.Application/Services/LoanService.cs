using GerenciadorBiblioteca.Application.DTOs.Loans;
using GerenciadorBiblioteca.Core.Interfaces.Repositories;
using GerenciadorBiblioteca.Core.Interfaces.Services;

namespace GerenciadorBiblioteca.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;

        public LoanService(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateLoanDto model)
        {
            var loan = model.ToEntity();

            await _repository.Create(loan);
        }

        public async Task<List<LoanDto>> GetAll()
        {
            var loans = await _repository.GetAll();

            var dto = loans.Select(LoanDto.FromEntity).ToList();

            return dto;
        }

        public async Task<LoanDto> GetById(int id)
        {
            var loan = await _repository.GetById(id);

            var dto = LoanDto.FromEntity(loan);

            return dto;
        }

        public async Task Update(int id,UpdateLoanDto model)
        {
            var loan = await _repository.GetById(id);

            loan.Update(model.ReturnDate);

            await _repository.Update(loan);
        }

        public async Task Delete(int id)
        {
            var loan = await _repository.GetById(id);

            loan.SetAsDeleted();

            await _repository.Update(loan);
        }

        public async Task<string> ReturnBook(int id)
        {
            var loan = await _repository.GetById(id);
            
            loan.ReturnBook();

            await _repository.Update(loan);

            return loan.ReturnDate.Date >= DateTime.Now.Date ? "Devolvido no prazo!" : "Empréstimo finalizado com atraso!"; ;
        }
    }
}
