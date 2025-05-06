using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Estacionamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController:ControllerBase
    {
          private readonly Contexto _context;

    public AluguelController(Contexto context)
    {
        _context = context;
    }
    
   /* [HttpPost("criar")]
    public async Task<IActionResult> CriarVaga([FromBody] VagaEstacionamento novaVaga)
    {
        _context.VagaEstacionamentos.Add(novaVaga);
        await _context.SaveChangesAsync();
        return Ok(novaVaga);
    }*/

    [HttpPost("criar")]
    public async Task<IActionResult> CriarVaga([FromBody] VagaDTO dto)
    {
        var vaga = new VagaEstacionamento
        {
            Disponivel = dto.Disponivel,
            EstacionamentoId = dto.EstacionamentoId
        };

    _context.VagaEstacionamentos.Add(vaga);
    await _context.SaveChangesAsync();

    return Ok(vaga);
}
  [HttpPost("reservar")]
public async Task<IActionResult> ReservarVaga([FromBody] ReservaVagaDTO dto)
{
    // Verifica se a vaga existe, está disponível e pertence ao estacionamento informado
    var vaga = await _context.VagaEstacionamentos
        .FirstOrDefaultAsync(v => v.Id == dto.VagaId && v.Disponivel && v.EstacionamentoId == dto.EstacionamentoId);

    if (vaga == null)
    {
        return BadRequest("Vaga não encontrada, já está ocupada ou não pertence ao estacionamento informado.");
    }

    // Verifica se o veículo existe
    var veiculo = await _context.Veiculo.FindAsync(dto.VeiculoId);
    if (veiculo == null)
    {
        return BadRequest("Veículo não encontrado.");
    }

    // Cria o aluguel
    var aluguel = new AluguelVaga
    {
        VagaEstacionamentoId = vaga.Id,
        VeiculoId = veiculo.Id,
        ValorDiaria = dto.Valor
    };

    // Atualiza a vaga para indisponível
    vaga.Disponivel = false;

    // Salva no banco
    _context.AluguelVagas.Add(aluguel);
    _context.VagaEstacionamentos.Update(vaga);
    await _context.SaveChangesAsync();

    return Ok(aluguel);
}
    }
}