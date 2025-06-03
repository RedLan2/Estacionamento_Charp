using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Estacionamento.Models
{
    public class Estacionamento
    {
     public int Id { get; set; }
     public String Nome { get; set; }
     public int CNPJ { get; set; }
     public int DonoId { get; set; } 
     public double ValorDiaria { get; set; }
      public List<VagaEstacionamento> Vagas { get; set; }

        [JsonIgnore]
        public virtual DonoEstacionamento DonoEstacionamento {get; set;}
  
         public int EnderecoId { get; set; }
       // [JsonIgnore]
        public Endereco Endereco { get; set; }
    }
}