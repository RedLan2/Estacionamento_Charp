using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class VagaEstacionamento
    {
    public int Id { get; set; }     
    public int vagaDisponivel { get; set; }

    public int vagaOcupada { get; set; }
    public int EstacionamentoId { get; set; }
      public Estacionamento Estacionamento { get; set; }

       public void ReverterVaga()
    {
        if (vagaOcupada > 0)
        {
            vagaOcupada--;
            vagaDisponivel++;
        }
    }

    // Método para ocupar uma vaga
    public void OcupadaVaga()
    {
        vagaOcupada++;
        vagaDisponivel--;
    }

    }
}