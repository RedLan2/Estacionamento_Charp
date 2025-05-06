using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class ReservaVagaDTO
    {
    public int VagaId { get; set; }
    public int VeiculoId { get; set; }
    public decimal Valor { get; set; }
    public int EstacionamentoId { get; set; }

    public static ReservaVagaDTO ConvertToDTO(VagaEstacionamento reservaVaga, AluguelVaga aluguelVaga)
    {
        return new ReservaVagaDTO
        {
               VagaId = aluguelVaga.VagaEstacionamentoId,
            VeiculoId = aluguelVaga.VeiculoId,
            Valor = aluguelVaga.ValorDiaria,
            EstacionamentoId = reservaVaga.EstacionamentoId
        };
    }
}}