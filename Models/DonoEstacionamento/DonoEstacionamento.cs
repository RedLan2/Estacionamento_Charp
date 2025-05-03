using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Estacionamento.Models
{
    public class DonoEstacionamento

    {  
         [Key]

        public int Id_Dono{ get; set; }
        public String Nome{ get; set; }
        public String Cpf_Dono { get; set; }
        public String Email { get; set; }
        public String Data_nascimento_dono { get; set; }

         [JsonIgnore]
        [NotMapped]
         public virtual ICollection<Estacionamento>? Estacionamentos { get; set; }

    }
}