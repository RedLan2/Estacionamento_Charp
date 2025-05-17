using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class DonoEstacionamentoDTO
    {
        public String Cpf_Dono { get; set; }
        public String Email { get; set; }

        public static DonoEstacionamentoDTO ConvertToDTO(DonoEstacionamento dono)
        {
            return new DonoEstacionamentoDTO
            {
                Cpf_Dono = dono.Cpf_Dono,
                Email = dono.Email
            };
        }
    }
}