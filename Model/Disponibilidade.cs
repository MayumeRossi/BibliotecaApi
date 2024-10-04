using System.Text.Json.Serialization;
using System;

namespace BibliotecaApi.Model
{
    public class Disponibilidade
    {
        public int Id { get; set; }
        public string status { get; set; }

        public int IdLivro { get; set; }

        public int IdCLiente { get; set; }

        public DateOnly DtRetirada { get; set; }

        public DateOnly DtDevolucao { get; set; }

        [JsonIgnore]
        public virtual Livro Livro { get; set; }

        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }

    }
}
