using GerenciadorBiblioteca.Core.Entities;

namespace GerenciadorBiblioteca.Application.DTOs.Books
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int PublicationYear { get; set; }

        public Book ToEntity() => new(Title, Author, Isbn, PublicationYear);
    }
}
