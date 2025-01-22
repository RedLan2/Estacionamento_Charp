using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class EstacionamentoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vagas { get; set; }
        public int DonoId { get; set; }
        public int CNPJ { get; set; }
        public double valorVaga { get; set; }


        public static EstacionamentoDTO ConvertToDTO(Estacionamento estacionamento)
        {
            return new EstacionamentoDTO
            {
                Id = estacionamento.Id,
                Nome = estacionamento.Nome,
                Vagas = estacionamento.vagas,
                DonoId = estacionamento.DonoId,
                CNPJ = estacionamento.CNPJ,
                valorVaga = estacionamento.valorVaga

            };
        }
    }
}
