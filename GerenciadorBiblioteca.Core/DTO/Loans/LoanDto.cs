using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Core.DTO.Loans
{
    public class LoanDto
    {
        public LoanDto(int id, int idUser, int idBook, string userName, string userEmail, string bookTitle, DateTime loanDate, DateTime returnDate, bool loanInProgress)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            UserName = userName;
            UserEmail = userEmail;
            BookTitle = bookTitle;
            LoanDate = loanDate;
            ReturnDate = returnDate;
            LoanInProgress = loanInProgress;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public string BookTitle { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public bool LoanInProgress { get; private set; }

        public static LoanDto FromEntity(Loan loan) => new(loan.Id, loan.IdUser, loan.IdBook, loan.User.Name, loan.User.Email, loan.Book.Title, loan.LoanDate, loan.ReturnDate, loan.LoanInProgress);
    }
}
