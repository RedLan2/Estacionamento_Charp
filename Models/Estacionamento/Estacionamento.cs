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

     public int vagas { get; set; }
     public double valorVaga { get; set; }
     public int DonoId { get; set; } 

      [JsonIgnore]
        [NotMapped]
        public virtual ICollection<ReservaEstacionament>? ReservaEstacionament { get; set; }
        
         public int VagasDisponiveis
    {
        get
        {
            int vagasOcupadas = VagasEstacionamento.Sum(v => v.vagaOcupada);
            return vagas - vagasOcupadas;
        }
    }

    public bool PodeOcuparVaga()
    {
        return VagasDisponiveis > 0;
    }

    public bool PodeLiberarVaga()
    {
        return VagasEstacionamento.Sum(v => v.vagaOcupada) > 0;
    }

    public void InicializarVagas()
    {
        foreach (var vaga in VagasEstacionamento)
        {
            vaga.vagaDisponivel = vagas;  // Inicializa com o número total de vagas disponíveis
            vaga.vagaOcupada = 0;         // Nenhuma vaga ocupada no início
        }
    }
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VagaEstacionamento> VagasEstacionamento { get; set; }

        [JsonIgnore]
        public virtual DonoEstacionamento DonoEstacionamento {get; set;}
        
         public int EnderecoId { get; set; }
        [JsonIgnore]
        public Endereco Endereco { get; set; }
    }
}