using BibliotecaApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace BibliotecaApi.BD
{
    public class BANCO : DbContext
    {
        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<Disponibilidade> Disponibilidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BibliotecaMay;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder
                .Entity<Livro>()
                .HasData(
                new Livro
                {
                    Id = 1,
                    Titulo = "A menina que roubava livros",
                    Descricao = "Filha de uma comunista perseguida pelo nazismo, Liesel é adotada por um casal alemão em troca de dinheiro. A menina logo se afeiçoa ao padrasto, Hans, que lhe ensina.",
                    Autor = "Markus Zusak",
                    DataLan = "2005"

                },
                new Livro
                {
                    Id = 2,
                    Titulo = "Eu Estive Aqui",
                    Descricao = "A história de Cody, uma jovem que busca respostas após o inesperado suicídio de sua melhor amiga, Meg, desvendando segredos sobre o que pode ter levado sua amiga a tomar essa decisão.",
                    Autor = "Gayle Forman",
                    DataLan = "2015"
                },
                new Livro
                {
                    Id = 3,
                    Titulo = "A Hospedeira",
                    Descricao = "Em um mundo onde alienígenas parasitas dominam o corpo e mente dos humanos, Melanie Stryder resiste, mesmo após ter sido capturada, lutando contra a invasão da sua própria consciência.",
                    Autor = "Stephenie Meyer",
                    DataLan = "2008"
                },
                new Livro
                {
                    Id = 4,
                    Titulo = "O Lado Feio do Amor",
                    Descricao = "Tate Collins e Miles Archer se envolvem em uma relação intensa, com um acordo claro de manter as coisas apenas físicas. No entanto, sentimentos não demoram a surgir, complicando a dinâmica entre eles.",
                    Autor = "Colleen Hoover",
                    DataLan = "2014"

                });


            modelBuilder
             .Entity<Cliente>()
             .HasData(
             new Cliente
             {
                 Id = 1,
                 Nome = "Nathalia",
                 Cpf = "002.005.755.09",
                 Telefone = "3565-4002"
             },
             new Cliente
             {
                 Id = 2,
                 Nome = "Lucas",
                 Cpf = "045.123.654.87",
                 Telefone = "9987-6654"
             },
             new Cliente
             {
                 Id = 3,
                 Nome = "Mariana",
                 Cpf = "321.654.987.01",
                 Telefone = "3498-1122"
             },
             new Cliente
             {
                 Id = 4,
                 Nome = "Gustavo",
                 Cpf = "785.321.456.10",
                 Telefone = "9876-5432"
             });



                }
            }
            }
