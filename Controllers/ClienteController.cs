using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Estacionamento.Models;

namespace Estacionamento.Controllers
{
     [ApiController]
    [Route("controller/cliente")]
    public class ClienteController: ControllerBase
    {
         private readonly Contexto _contexto;

        public ClienteController(Contexto contexto){
                    _contexto=contexto;
        }

         [HttpPost("CriarCliente")] 
            public IActionResult Create(Cliente cliente){
                _contexto.Add(cliente);
                _contexto.SaveChanges();
                return Ok(cliente);
            }

            [HttpPost("LoginCliente")]
            public IActionResult LoginCliente([FromBody] ClienteDTO clienteDTO){
                var clienteLogin = _contexto.Cliente.FirstOrDefault(c => c.Email == clienteDTO.Email && c.CPF == clienteDTO.CPF);
                if(clienteLogin == null){
                    return NotFound("Cliente não encontrado");
                }
                return Ok("logado");
            }
    }
}