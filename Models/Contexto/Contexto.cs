using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Estacionamento.Models
{
    public class Contexto: DbContext
    {
         public Contexto(DbContextOptions<Contexto>options): base(options){

        }

        public DbSet<Cliente> Cliente{get; set;}

        public DbSet<Veiculo> Veiculo{get;set;}

        public DbSet<DonoEstacionamento> DonoEstacionamentos{get;set;}
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estacionamento> Estacionamentos{get;set;}
        public DbSet<VagaEstacionamento> VagaEstacionamentos{get;set;}
        public DbSet<AluguelVaga> AluguelVagas{get;set;}


           protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Veiculo>()
            .HasOne(a => a.cliente)
            .WithMany(c => c.Veiculo)
            .HasForeignKey(c => c.clienteId)
            .IsRequired();

        modelBuilder.Entity<Estacionamento>()
        .HasOne(e => e.DonoEstacionamento)
        .WithMany(d => d.Estacionamentos)
        .HasForeignKey(e => e.DonoId)
        .IsRequired();    


            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Estacionamento)
                .WithOne(e => e.Endereco)
                .HasForeignKey(e => e.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);

         modelBuilder.Entity<Estacionamento>()
            .HasMany(e => e.Vagas)
            .WithOne(v => v.Estacionamento)
            .HasForeignKey(v => v.EstacionamentoId)
            .OnDelete(DeleteBehavior.Cascade);
            
             modelBuilder.Entity<AluguelVaga>()
            .HasOne<VagaEstacionamento>()
            .WithMany()
            .HasForeignKey(a => a.VagaEstacionamentoId);
          
                
    }
    }
}
