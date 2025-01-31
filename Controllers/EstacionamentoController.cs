using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;


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
                        DonoId  = estacionamentoDTO.DonoId,
                        CNPJ = estacionamentoDTO.CNPJ,
                        valorVaga = estacionamentoDTO.valorVaga
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
                
                 var estacionamento = _contexto.Estacionamentos
                                  .Include(e => e.VagasEstacionamento)
                                  .FirstOrDefault(e => e.Id == reservaEstacionamentoDTO.EstacionamentoId);

                if (estacionamento != null && estacionamento.VagasEstacionamento != null)
                {
                    // Encontra a vaga disponível (se houver)
                    var vagaDisponivel = estacionamento.VagasEstacionamento
                                                    .FirstOrDefault(v => v.vagaOcupada < 1); // Vaga disponível, ou seja, não ocupada

                    if (vagaDisponivel != null)
                    {
                        // Atualiza a vaga, ocupando-a
                        vagaDisponivel.OcupadaVaga(); // Método que aumenta vagaOcupada e diminui vagaDisponivel
                        _contexto.Update(vagaDisponivel);
                        _contexto.SaveChanges();
                    }
                    else
                    {
                        // Caso não haja vagas disponíveis, retorne uma resposta informando
                        return BadRequest("Não há vagas disponíveis no estacionamento.");
                    }
                }
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

    [HttpGet("ListarEstacionamentos")]
    public IActionResult ListarEstacionamentos(){
        var estacionamentos = _contexto.Estacionamentos.ToList();
        return Ok(estacionamentos);
    }
    [HttpPost("CriarEndereco")]
    public IActionResult Create(Endereco endereco){
        _contexto.Add(endereco);
        _contexto.SaveChanges();
        return Ok(endereco);
    }
    [HttpGet("VagasEstacionamento/{estacionamentoId}")]
    public IActionResult VagasEstacionamento(int estacionamentoId){
      
    var estacionamento = _contexto.Estacionamentos.FirstOrDefault(e => e.Id == estacionamentoId);
    if (estacionamento == null)
    {
        return NotFound("Estacionamento não encontrado");
    }

    int vagas = estacionamento.vagas;
    return Ok(vagas);
   

    }
}}
