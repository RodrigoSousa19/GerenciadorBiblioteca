using GerenciadorBiblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorBiblioteca.Infrastructure.Data.Configurations
{
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.User)
                   .WithOne()
                   .HasForeignKey<Loan>(l => l.IdUser)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Book)
                   .WithOne()
                   .HasForeignKey<Loan>(l => l.IdBook)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
