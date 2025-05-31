using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Models
{
    public class ClienteDTO
    {
          public String CPF { get; set; } 
        [Required(ErrorMessage = "Senha é obrigatória")]
        public String Senha { get; set; }

        public static ClienteDTO ConvertToDTO(Cliente cliente)
        {
            return new ClienteDTO
            {
                CPF = cliente.CPF,
                Senha = cliente.Senha
            };
        }
    }
}