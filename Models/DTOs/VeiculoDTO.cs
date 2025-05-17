using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class VeiculoDTO
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int ClienteId { get; set; }

         public VeiculoDTO ConvertToDTO(Veiculo veiculo)
            {
                return new VeiculoDTO
                {
                    Id = veiculo.Id,
                    Modelo = veiculo.modelo,
                    Placa = veiculo.placa,
                    ClienteId = veiculo.clienteId
                };
            }
    }

   

}