using BibliotecaApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BibliotecaApi.BD.Config
{
    public class DisponibilidadeConfig : IEntityTypeConfiguration<Disponibilidade>
    {
        public void Configure(EntityTypeBuilder<Disponibilidade> builder)
        {
            builder.ToTable("Disponibilidade");

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.status)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder
                .Property(p => p.IdLivro)
                .IsRequired(true);


            builder
                .Property(p => p.IdCLiente)
                .IsRequired(true);

            builder
               .Property(p => p.DtDevolucao)
                .HasColumnType("date")
                .IsRequired(true);

            builder
              .Property(p => p.DtRetirada)
               .HasColumnType("date")
               .IsRequired(true);

            builder
                  .HasOne(d => d.Livro)  // Disponibilidade tem um Livro
                  .WithOne(l => l.Disponibilidade)  // Livro tem uma Disponibilidade
                  .HasForeignKey<Disponibilidade>(d => d.IdLivro)  // Usar IdLivro como chave estrangeira
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Cascade);  // Exclusão em cascata

            // Configurar relação com Cliente (1:1)
            builder
                .HasOne(d => d.Cliente)  // Disponi
                .WithOne(c => c.Disponibilidade)  // Cliente tem uma Disponibilidade
                .HasForeignKey<Disponibilidade>(d => d.IdCLiente)  // Usar IdCliente como chave estrangeira
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }






}