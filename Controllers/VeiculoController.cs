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
    public class VeiculoController :ControllerBase
    {   
         private readonly Contexto _contexto;

        public VeiculoController(Contexto contexto){
                    _contexto=contexto;
        }       

         [HttpPost("CriarVeiculo")]
            public IActionResult Create(VeiculoDTO veiculoDTO){

                 var clienteExiste = _contexto.Cliente.Any(c => c.Id == veiculoDTO.ClienteId);
                if (!clienteExiste)
                {
                    return BadRequest($"Cliente com ID {veiculoDTO.ClienteId} não existe.");
                }
                var veiculo = new Veiculo
                    {
                        modelo = veiculoDTO.Modelo,
                        placa = veiculoDTO.Placa,
                        clienteId = veiculoDTO.ClienteId
                    };
                _contexto.Add(veiculo);
                _contexto.SaveChanges();
                return Ok(veiculoDTO);
            }

             [HttpGet("ListarVeiculos/{clienteId}")]
             public IActionResult ListarVeiculo(int clienteId){
               var veiculos = _contexto.Veiculo.Where(v => v.clienteId == clienteId).ToList();
             if (veiculos == null )
             {
                 return NotFound("Nenhum veículo encontrado para este dono.");
             }
             return Ok(veiculos);
    }

    }
}