﻿// <auto-generated />
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Estacionamento.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20250131161425_AdicionarCampoVagaDisponivel")]
    partial class AdicionarCampoVagaDisponivel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Estacionamento.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Data_nascimento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Estacionamento.Models.DonoEstacionamento", b =>
                {
                    b.Property<int>("Id_Dono")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf_Dono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Data_nascimento_dono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_Dono");

                    b.ToTable("DonoEstacionamentos");
                });

            modelBuilder.Entity("Estacionamento.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Estacionamento.Models.Estacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CNPJ")
                        .HasColumnType("int");

                    b.Property<int>("DonoId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("vagas")
                        .HasColumnType("int");

                    b.Property<double>("valorVaga")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DonoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("Estacionamento.Models.ReservaEstacionament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("EstacionamentoId")
                        .HasColumnType("int");

                    b.Property<string>("placa")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstacionamentoId");

                    b.HasIndex("placa");

                    b.ToTable("ReservaEstacionaments");
                });

            modelBuilder.Entity("Estacionamento.Models.VagaEstacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EstacionamentoId")
                        .HasColumnType("int");

                    b.Property<int>("vagaDisponivel")
                        .HasColumnType("int");

                    b.Property<int>("vagaOcupada")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstacionamentoId");

                    b.ToTable("VagaEstacionamentos");
                });

            modelBuilder.Entity("Estacionamento.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<string>("modelo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("placa")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("clienteId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("Estacionamento.Models.Estacionamento", b =>
                {
                    b.HasOne("Estacionamento.Models.DonoEstacionamento", "DonoEstacionamento")
                        .WithMany("Estacionamentos")
                        .HasForeignKey("DonoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Estacionamento.Models.Endereco", "Endereco")
                        .WithMany("Estacionamentos")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonoEstacionamento");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Estacionamento.Models.ReservaEstacionament", b =>
                {
                    b.HasOne("Estacionamento.Models.Cliente", "Cliente")
                        .WithMany("ReservaEstacionament")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Estacionamento.Models.Estacionamento", "Estacionamento")
                        .WithMany("ReservaEstacionament")
                        .HasForeignKey("EstacionamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Estacionamento.Models.Veiculo", "Veiculo")
                        .WithMany("ReservaEstacionament")
                        .HasForeignKey("placa")
                        .HasPrincipalKey("placa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Estacionamento");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Estacionamento.Models.VagaEstacionamento", b =>
                {
                    b.HasOne("Estacionamento.Models.Estacionamento", "Estacionamento")
                        .WithMany("VagasEstacionamento")
                        .HasForeignKey("EstacionamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estacionamento");
                });

            modelBuilder.Entity("Estacionamento.Models.Veiculo", b =>
                {
                    b.HasOne("Estacionamento.Models.Cliente", "cliente")
                        .WithMany("Veiculo")
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("Estacionamento.Models.Cliente", b =>
                {
                    b.Navigation("ReservaEstacionament");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Estacionamento.Models.DonoEstacionamento", b =>
                {
                    b.Navigation("Estacionamentos");
                });

            modelBuilder.Entity("Estacionamento.Models.Endereco", b =>
                {
                    b.Navigation("Estacionamentos");
                });

            modelBuilder.Entity("Estacionamento.Models.Estacionamento", b =>
                {
                    b.Navigation("ReservaEstacionament");

                    b.Navigation("VagasEstacionamento");
                });

            modelBuilder.Entity("Estacionamento.Models.Veiculo", b =>
                {
                    b.Navigation("ReservaEstacionament");
                });
#pragma warning restore 612, 618
        }
    }
}
