namespace GerenciadorBiblioteca.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book() { }
        public Book(string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;

            SetAvailableForLoan();
        }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public bool AvailableForLoan { get; private set; }

        public void SetAvailableForLoan() => AvailableForLoan = true;
        public void SetUnavailableForLoan() => AvailableForLoan = false;

        public void Update(string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
            UpdatedAt = DateTime.Now;
        }
    }
}
