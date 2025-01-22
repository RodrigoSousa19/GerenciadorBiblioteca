namespace GerenciadorBiblioteca.Application.DTO.Books
{
    public class UpdateBookDto
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int PublicationYear { get; set; }
    }
}
