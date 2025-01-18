using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Estacionamento.Models
{
    public class ReservaEstacionament
    {
        public int Id { get; set; }
        public int EstacionamentoId { get; set; }
        public int ClienteId { get; set; }
        public string placa { get; set; }

       [JsonIgnore]
          public virtual Estacionamento Estacionamento { get; set; }
          [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        [JsonIgnore]
        public virtual Veiculo Veiculo { get; set; }

    }
}