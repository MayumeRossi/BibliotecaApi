using BibliotecaApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BibliotecaApi.BD.Config
{
    public class LivroConfig : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            builder
                .Property(p => p.Autor)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            builder
               .Property(p => p.Descricao)
               .IsRequired()
               .HasMaxLength(1000)
               .IsUnicode(false);
            builder
                .Property(p => p.DataLan)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

        }
    }
}
