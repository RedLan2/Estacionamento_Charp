using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class AluguelVaga
    {
        public int Id { get; set; }
        public int VagaEstacionamentoId { get; set; }
        public VagaEstacionamento VagaEstacionamento { get; set; }
        public decimal ValorDiaria { get; set; }

        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}