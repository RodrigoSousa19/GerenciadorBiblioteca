using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Application.DTOs.Loans
{
    public class LoanItemDto
    {
        public LoanItemDto(int id, string userName, string userEmail, string bookTitle, string bookISBN, DateTime loanDate, DateTime returnDate)
        {
            Id = id;
            UserName = userName;
            UserEmail = userEmail;
            BookTitle = bookTitle;
            BookISBN = bookISBN;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public string BookTitle { get; private set; }
        public string BookISBN { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public static LoanItemDto FromEntity(Loan loan) => new(loan.Id, loan.User.Name, loan.User.Email, loan.Book.Title, loan.Book.ISBN, loan.LoanDate, loan.ReturnDate);
    }
}
