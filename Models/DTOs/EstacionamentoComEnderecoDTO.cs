using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class EstacionamentoComEnderecoDTO
    {
        public EstacionamentoDTO EstacionamentoDTO { get; set; }
         public EnderecoDTO EnderecoDTO { get; set; }
    }
}