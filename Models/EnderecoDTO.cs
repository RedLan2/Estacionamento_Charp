using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        public EnderecoDTO(int id, string rua, string numero, string complemento, string cep)
        {
            Id = id;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
        }
        public EnderecoDTO() { } // Construtor padrão para o Entity Framework
    }
}