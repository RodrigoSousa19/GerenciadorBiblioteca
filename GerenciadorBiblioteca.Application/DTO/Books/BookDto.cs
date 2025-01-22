using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Application.DTO.Books
{
    public class BookDto
    {
        public BookDto(string title, string author, string isbn, int publicationYear, bool availableForLoan)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            PublicationYear = publicationYear;
            AvailableForLoan = availableForLoan;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public int PublicationYear { get; private set; }
        public bool AvailableForLoan { get; private set; }

        public static BookDto FromEntity(Book book) => new(book.Title, book.Author, book.ISBN, book.PublicationYear, book.AvailableForLoan);
    }
}
