using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Estacionamento.Models
{
    public class VagaEstacionamento
    {
        public int Id { get; set; }
    public bool Disponivel { get; set; }

    
    public int EstacionamentoId { get; set; }
    
    public Estacionamento Estacionamento { get; set; }
    }
}