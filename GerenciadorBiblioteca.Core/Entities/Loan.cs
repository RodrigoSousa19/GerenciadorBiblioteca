namespace GerenciadorBiblioteca.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan() { }

        public Loan(int idUser, int idBook, DateTime returnDate)
        {
            LoanDate = DateTime.Now;
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;

            SetLoanInProgress();
        }

        public DateTime LoanDate { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public bool LoanInProgress { get; private set; }

        public void SetLoanInProgress() => LoanInProgress = true;
        public void ReturnBook() => LoanInProgress = false;

        public void Update(DateTime newReturnDate)
        {
            ReturnDate = newReturnDate;
        }
    }
}
