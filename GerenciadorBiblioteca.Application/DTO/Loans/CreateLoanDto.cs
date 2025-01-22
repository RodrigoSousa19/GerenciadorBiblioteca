using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Application.DTO.Loans
{
    public class CreateLoanDto
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime ReturnDate { get; set; }

        public Loan ToEntity() => new(IdUser, IdBook, ReturnDate);
    }
}
