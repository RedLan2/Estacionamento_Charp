using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

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

            //Metodo para ve as reservas do cliente
            [HttpGet("reserva-cliente/{veiculoId}")]
public async Task<IActionResult> ObterReservaDoCliente(int veiculoId)
{
    var reserva = await _contexto.AluguelVagas
    .Include(a => a.Veiculo)
    .Include(a => a.VagaEstacionamento)
        .ThenInclude(v => v.Estacionamento)
    .FirstOrDefaultAsync(a => a.VeiculoId == veiculoId);

    if (reserva == null)
    {
        return NotFound("Nenhuma reserva encontrada para este veículo.");
    }

    var resultado = new
    {
        ReservaId = reserva.Id,
        ValorDiaria = reserva.ValorDiaria,
        Veiculo = new
        {
            reserva.Veiculo.Id,
            reserva.Veiculo.placa,
            reserva.Veiculo.modelo
        },
        Vaga = new
        {
            reserva.VagaEstacionamento.Id,
            reserva.VagaEstacionamento.Disponivel
        },
        Estacionamento = new
        {
            reserva.VagaEstacionamento.Estacionamento.Id,
            reserva.VagaEstacionamento.Estacionamento.Nome,
            reserva.VagaEstacionamento.Estacionamento.CNPJ
        }
    };

    return Ok(resultado);
}
    }
}