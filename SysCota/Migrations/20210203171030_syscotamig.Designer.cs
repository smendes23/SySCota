﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SysCota.Data;

namespace SysCota.Migrations
{
    [DbContext(typeof(DBCOTACAOContext))]
    [Migration("20210203171030_syscotamig")]
    partial class syscotamig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SysCota.Models.Cotacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("DataCotacao");

                    b.Property<DateTime>("DataEntregaCotacao");

                    b.Property<int>("FornecedorId");

                    b.Property<int>("NumeroDaCotacao");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Cotacoes");
                });

            modelBuilder.Entity("SysCota.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsFornecedor");

                    b.Property<string>("RazaoSocial");

                    b.HasKey("Id");

                    b.ToTable("Empresas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Empresa");
                });

            modelBuilder.Entity("SysCota.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep")
                        .IsRequired();

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Observacao");

                    b.Property<string>("Uf");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("SysCota.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CotarId");

                    b.Property<long>("NumeroItem");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("CotarId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("SysCota.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("SysCota.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("MarcaId");

                    b.Property<decimal>("Preco");

                    b.Property<int>("UnidadeId");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SysCota.Models.Unidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("SysCota.Models.Cliente", b =>
                {
                    b.HasBaseType("SysCota.Models.Empresa");


                    b.ToTable("Cliente");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("SysCota.Models.Fornecedor", b =>
                {
                    b.HasBaseType("SysCota.Models.Empresa");


                    b.ToTable("Fornecedor");

                    b.HasDiscriminator().HasValue("Fornecedor");
                });

            modelBuilder.Entity("SysCota.Models.Cotacao", b =>
                {
                    b.HasOne("SysCota.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SysCota.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SysCota.Models.Endereco", b =>
                {
                    b.HasOne("SysCota.Models.Empresa", "Empresa")
                        .WithMany("Enderecos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SysCota.Models.Item", b =>
                {
                    b.HasOne("SysCota.Models.Cotacao", "Cotar")
                        .WithMany("Itens")
                        .HasForeignKey("CotarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SysCota.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SysCota.Models.Produto", b =>
                {
                    b.HasOne("SysCota.Models.Marca", "Marca")
                        .WithMany("Produtos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SysCota.Models.Unidade", "Unidade")
                        .WithMany("Produtos")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
