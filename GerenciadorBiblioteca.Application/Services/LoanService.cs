using GerenciadorBiblioteca.Core.DTO.Loans;
using GerenciadorBiblioteca.Core.Interfaces.Repositories;
using GerenciadorBiblioteca.Core.Interfaces.Services;

namespace GerenciadorBiblioteca.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;
        private readonly IBookService _bookService;

        public LoanService(ILoanRepository repository, IBookService bookService)
        {
            _repository = repository;
            _bookService = bookService;
        }

        public async Task Create(CreateLoanDto model)
        {
            var loan = model.ToEntity();

            await _repository.Create(loan);

            await _bookService.SetUnavailableForLoan(loan.IdBook);
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

            if (loan is null)
                return null;

            var dto = LoanDto.FromEntity(loan);

            return dto;
        }

        public async Task Update(int id, UpdateLoanDto model)
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

            if (!loan.LoanInProgress)
            {
                return "Este empréstimo não está mais em andamento!";
            }

            loan.ReturnBook();

            await _repository.Update(loan);
            await _bookService.SetAvailableForLoan(loan.IdBook);

            return loan.ReturnDate.Date >= DateTime.Now.Date ? "Devolvido no prazo!" : "Empréstimo finalizado com atraso!"; ;

        }
    }
}
