using GerenciadorBiblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorBiblioteca.Infrastructure.Data.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(b => b.ISBN)
                .IsRequired();

        }
    }
}
