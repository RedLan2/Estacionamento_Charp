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
        [EmailAddress(ErrorMessage = "Email inválido")]
        public String Email { get; set; }

        public static ClienteDTO ConvertToDTO(Cliente cliente)
        {
            return new ClienteDTO
            {
                CPF = cliente.CPF,
                Email = cliente.Email
            };
        }
    }
}