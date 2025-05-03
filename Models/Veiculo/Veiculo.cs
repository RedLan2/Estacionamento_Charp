using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Estacionamento.Models

{
    public class Veiculo
    {
         public int Id  { get; set; }
        public string modelo  { get; set; }
        public string placa  { get; set; }
        public int clienteId  { get; set; }

        [JsonIgnore]
        public virtual Cliente cliente {get; set;}
        
    
    }
}