using System.Text.Json.Serialization;
using System;

namespace BibliotecaApi.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
       
        public string Telefone { get; set; }

        [JsonIgnore]
        public virtual Disponibilidade  Disponibilidade { get; set; }
    }
}
