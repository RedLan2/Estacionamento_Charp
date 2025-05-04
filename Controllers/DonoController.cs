using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Estacionamento.Models;
namespace Estacionamento.Controllers
{
    

    [ApiController]
    [Route("controller/dono")]
    public class DonoController : ControllerBase
    {
        private readonly Contexto _contexto;

        public DonoController(Contexto contexto)
        {
            _contexto = contexto;
        }

       [HttpPost("CriarDonoEstacionamento")]
            public IActionResult Create(DonoEstacionamento donoEstacionamento){
                _contexto.Add(donoEstacionamento);
                _contexto.SaveChanges();
                return Ok(donoEstacionamento);
            }


             [HttpPost("LoginDonoEstacionamento")]  
            public IActionResult LoginDonoEstacionamento([FromBody] DonoEstacionamentoDTO DonoEstacionamentoDTO){
                var donoEstacionamentoLogin = _contexto.DonoEstacionamentos.FirstOrDefault(d => d.Email == DonoEstacionamentoDTO.Email && d.Cpf_Dono == DonoEstacionamentoDTO.Cpf_Dono);
                if(donoEstacionamentoLogin == null){
                    return NotFound("Dono de estacionamento não encontrado");
                }
                return Ok("logado");
            }
    }
}