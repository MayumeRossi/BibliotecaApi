using BibliotecaApi.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace BibliotecaApi.BD.Config
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            builder
                .Property(p => p.Cpf)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            builder
                .Property(p => p.Telefone)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

        }
    }
}
