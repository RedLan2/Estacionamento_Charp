using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Estacionamento.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        [RegularExpression(@"^\d{8,11}$", ErrorMessage = "O telefone deve ter entre 8 e 11 dígitos.")]
        public String Telefone { get; set; }
        public String CPF { get; set; } 
        [EmailAddress(ErrorMessage = "Email inválido")]
        public String Email { get; set; }        
        public String Data_nascimento { get; set; }                                                                                          
        public bool Ativo { get; set; } = true;
        

        [JsonIgnore]
        [NotMapped]
         public virtual ICollection<Veiculo>? Veiculo { get; set; }

    }
}