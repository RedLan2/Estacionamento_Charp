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
           
          
            

            [HttpPost("CriarEstacionametoEndereco")]
            public IActionResult Create(EstacionamentoDTO estacionamentoDTO,EnderecoDTO enderecoDTO){
                  var estacionamento = new Models.Estacionamento
                    {
                        Nome = estacionamentoDTO.Nome,
                        CNPJ = estacionamentoDTO.CNPJ,
                        DonoId = estacionamentoDTO.DonoId,
                        EnderecoId = estacionamentoDTO.EnderecoId
                       
                    };
                    var endereco = new Models.Endereco
                    {
                        Rua = enderecoDTO.Rua,
                        Numero = enderecoDTO.Numero,
                        Complemento = enderecoDTO.Complemento,
                        Cep = enderecoDTO.Cep
                    };


                    _contexto.Add(endereco);
                    // Adiciona o estacionamento ao contexto e salva no banco
                    _contexto.Add(estacionamento);
                    _contexto.SaveChanges(); // Salva para gerar o ID do estacionamento no banco
            

                    return Ok(estacionamentoDTO);
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
 



}}
