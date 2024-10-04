using System.Text.Json.Serialization;
using System;

namespace BibliotecaApi.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string DataLan{ get; set; }
        public string Descricao { get; set; }

        [JsonIgnore]
        public virtual Disponibilidade Disponibilidade { get; set; }
    }
}

