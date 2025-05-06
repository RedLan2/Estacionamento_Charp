using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class VagaDTO
    {
         public bool Disponivel { get; set; }
        public int EstacionamentoId { get; set; }
    }
}