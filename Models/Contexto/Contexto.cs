using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<ReservaEstacionament> ReservaEstacionaments { get; set; }
        public DbSet<VagaEstacionamento> VagaEstacionamentos { get; set; }


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

         modelBuilder.Entity<ReservaEstacionament>()
            .HasOne(r => r.Estacionamento)
            .WithMany(e => e.ReservaEstacionament)
            .HasForeignKey(r => r.EstacionamentoId)
            .IsRequired();

        modelBuilder.Entity<ReservaEstacionament>()
            .HasOne(r => r.Cliente)
            .WithMany(c => c.ReservaEstacionament)
            .HasForeignKey(r => r.ClienteId)
            .IsRequired();

     modelBuilder.Entity<ReservaEstacionament>()
            .HasOne(r => r.Veiculo)
            .WithMany(v => v.ReservaEstacionament)
            .HasForeignKey(r => r.placa)
            .HasPrincipalKey(v => v.placa)
            .IsRequired();

            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Estacionamentos)
                .WithOne(e => e.Endereco)
                .HasForeignKey(e => e.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<VagaEstacionamento>()
                    .HasOne(v => v.Estacionamento)  // Relacionamento 1:N com Estacionamento
                    .WithMany(e => e.VagasEstacionamento)  // Estacionamento tem muitas Vagas
                    .HasForeignKey(v => v.EstacionamentoId)  // A chave estrangeira é EstacionamentoId
                    .OnDelete(DeleteBehavior.Cascade);
    }
    }
}
