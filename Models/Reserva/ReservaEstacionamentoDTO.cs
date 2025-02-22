using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class ReservaEstacionamentoDTO
    {
        [Key]
         public int Id { get; set; }
        public int EstacionamentoId { get; set; }
        public int ClienteId { get; set; }
        public string Placa { get; set; }
    }
}