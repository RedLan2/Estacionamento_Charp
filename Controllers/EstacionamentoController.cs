using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Estacionamento.Models;

namespace Estacionamento.Controllers
{   [ApiController]
    [Route("[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly Contexto _contexto;

        public EstacionamentoController(Contexto contexto){
                    _contexto=contexto;
        }
            [HttpPost("CriarCliente")] 
            public IActionResult Create(Cliente cliente){
                _contexto.Add(cliente);
                _contexto.SaveChanges();
                return Ok(cliente);
            }
            [HttpPost("CriarDonoEstacionamento")]
            public IActionResult Create(DonoEstacionamento donoEstacionamento){
                _contexto.Add(donoEstacionamento);
                _contexto.SaveChanges();
                return Ok(donoEstacionamento);
            }
           
          /*  public IActionResult Create(Veiculo veiculo){

                _contexto.Add(veiculo);
                _contexto.SaveChanges();
                return Ok(veiculo);
            }*/
             [HttpPost("CriarVeiculo")]
            public IActionResult Create(VeiculoDTO veiculoDTO){
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

            [HttpPost("CriarEstacionameto")]
            public IActionResult Create(EstacionamentoDTO estacionamentoDTO){
                var estacionameto = new Models.Estacionamento
                    {
                        Nome = estacionamentoDTO.Nome,
                        vagas = estacionamentoDTO.Vagas,
                        DonoId  = estacionamentoDTO.DonoId
                    };
                _contexto.Add(estacionameto);
                _contexto.SaveChanges();
                return Ok(estacionamentoDTO);
            }
            [HttpPost("CriarReservaEstacionamento")]
            public IActionResult Create(ReservaEstacionamentoDTO reservaEstacionamentoDTO){
                var reservaEstacionamento = new ReservaEstacionament
                    {
                        EstacionamentoId = reservaEstacionamentoDTO.EstacionamentoId,
                        ClienteId = reservaEstacionamentoDTO.ClienteId,
                        placa = reservaEstacionamentoDTO.Placa
                    };
                _contexto.Add(reservaEstacionamento);
                _contexto.SaveChanges();
                return Ok(reservaEstacionamentoDTO);
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
}}
